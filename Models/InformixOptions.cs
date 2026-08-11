namespace Legacy.Models;
public sealed class InformixOptions
{
    public const string SectionName = "Informix";
    public string Host { get; init; } = "10.240.0.4";
    public int Port { get; init; } = 1547;
    public string Server { get; init; } = "synergia_test";
    public string Database { get; init; } = "synergia";
    public string UserId { get; init; } = "batchsyn";
    public string Password { get; init; } = "pepe";
}
