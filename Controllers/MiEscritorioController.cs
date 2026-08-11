using Microsoft.AspNetCore.Mvc;
using System.Data.Odbc;
using Legacy.Models;


namespace Legacy.Controllers
{
    public class MiEscritorioController : Controller
    {
        private readonly InformixConnection _informixConnection;
        
        public MiEscritorioController(InformixConnection informixConnection)
        {
            _informixConnection = informixConnection;
        }

        public IActionResult Index()
        {
            ViewBag.UserRole = "Administrador";
            ViewData["Title"] = "Mi Escritorio";
            return View(new MiEscritorioViewModel());
        }

        [HttpGet]
        [ActionName(nameof(GetMiEscritorioAsync))]
        public async Task<ActionResult<IReadOnlyList<TraspasoMensajeViewModel>>> GetMiEscritorioAsync(string rol, CancellationToken cancellationToken)
        {
            await using var connection = _informixConnection.CreateConnection();
            await connection.OpenAsync(cancellationToken);
            await using var command = new OdbcCommand(MiEscritorioSql, connection);
            command.Parameters.Add("rol", OdbcType.VarChar).Value = rol;
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);

            var result = new List<TraspasoMensajeViewModel>();
            while (await reader.ReadAsync(cancellationToken))
            {
                result.Add(new TraspasoMensajeViewModel
                {
                    NroMensaje = reader.IsDBNull(0) ? 0 : Convert.ToInt64(reader.GetValue(0)),
                    Referencia = _informixConnection.GetString(reader, 1)!,
                    RolAnterior = _informixConnection.GetString(reader, 2)!,
                    RolActual = _informixConnection.GetString(reader, 3)!,
                    FechaTraspaso = reader.IsDBNull(4) ? DateTime.MinValue : Convert.ToDateTime(reader.GetValue(4)),
                    Etiqueta = _informixConnection.GetString(reader, 5)!,
                    Procedimiento = _informixConnection.GetString(reader, 6)!
                });                
                   
            }

            return Ok(result);
        }

        [HttpGet]
        [ActionName(nameof(GetRolesAsync))]
        public async Task<ActionResult<IReadOnlyList<string>>> GetRolesAsync([FromQuery] string? rol, CancellationToken cancellationToken)
        {

            if (string.IsNullOrWhiteSpace(rol))
            {
                return BadRequest("El rol es obligatorio.");
            }

            await using var connection = _informixConnection.CreateConnection();
            await connection.OpenAsync(cancellationToken);
            await using var command = new OdbcCommand(RolesSql, connection);
            command.Parameters.Add("rol", OdbcType.VarChar).Value = rol.Trim().ToUpperInvariant();
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);

            var result = new List<string>();
            while (await reader.ReadAsync(cancellationToken))
            {
                result.Add(_informixConnection.GetString(reader, 1)!);
            }

            return Ok(result);
        }


        private const string RolesSql = """
            SELECT orden, rol_a FROM xnear2:repres
            WHERE rol = ?
            ORDER BY orden, rol_a ASC
            """;

        private const string MiEscritorioSql = """
            SELECT m.mensaje, m.referencia,
                m.rol_anterior,
                m.rol_actual,
                m.fecha_traspaso,
                'EDESUR-' || m.mensaje etiqueta,
                m.proced
            FROM xnear2:mensaje m, xnear2:referencia r
            WHERE m.servidor = 1
            AND m.rol_actual = ?
            AND m.estado <> '5'
            AND r.servidor = m.servidor
            AND r.mensaje = m.mensaje
            AND r.carpeta = m.rol_actual
            ORDER BY 1 DESC
            """;

    }
}
