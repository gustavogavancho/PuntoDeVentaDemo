namespace PuntoDeVentaDemo.COMMON.Interfaces
{
    public interface IMySqlWOConnection
    {
        string Error { get; }
        bool Comando(string command);
        object Consulta(string consulta);
    }
}
