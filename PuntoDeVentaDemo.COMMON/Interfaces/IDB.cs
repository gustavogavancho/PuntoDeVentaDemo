namespace PuntoDeVentaDemo.COMMON.Interfaces
{
    public interface IDB
    {
        string Error { get; }
        bool Comando(string command);
        object Consulta(string consulta);
    }
}
