public class Cliente{
    public int DNI {get;private set;}
    public string Apellido {get;private set;}
    public string Nombre {get;private set;}
    public DateTime FechaInscripcion {get; set;}
    public int TipoEntrada {get; set;}
    public double TotalAbonado {get; set;}

    public Cliente(int dni, string apellido, string nombre, DateTime fecha, int tipoentrada, double abonado){
        DNI = dni;
        Apellido = apellido;
        Nombre = nombre;
        FechaInscripcion = fecha;
        TipoEntrada = tipoentrada;
        TotalAbonado = abonado;
    }
}