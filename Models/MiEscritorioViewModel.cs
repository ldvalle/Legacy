namespace Legacy.Models;

public class MiEscritorioViewModel
{
    public IReadOnlyList<TraspasoMensajeViewModel> Mensajes { get; init; } = [];
}

public class TraspasoMensajeViewModel
{
    public long NroMensaje { get; init; }
    public string Referencia { get; init; } = string.Empty;
    public string RolAnterior { get; init; } = string.Empty;
    public string RolActual { get; init; } = string.Empty;
    public DateTime FechaTraspaso { get; init; }
    public string Etiqueta { get; init; } = string.Empty;
    public string Procedimiento { get; init; } = string.Empty;
}