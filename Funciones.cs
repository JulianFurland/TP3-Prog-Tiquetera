public static class Funciones{
    public static int IngresarEntero(string msj){
        int n;
        Console.WriteLine(msj);
        while(!int.TryParse(Console.ReadLine(),out n)){
            Console.WriteLine("El numero ingresado no es un entero, intente otra vez:");
        }
        return n;
    }
    public static string IngresarStr(string msj){
        Console.WriteLine(msj);
        string s = Console.ReadLine();
        while(s ==""){
            Console.WriteLine("El ingreso fue nulo, ingrese de nuevo:");
            s = Console.ReadLine();
        }
        return s;
    }
    public static int IngresarEnteroConRango(string msj, int min, int max){
        int n = IngresarEntero(msj);
        while(n < min || n > max){
            Console.WriteLine("El ingreso esta fuera del rango aceptado, ingresá de nuevo:");
            n = IngresarEntero("");
        }
        return n;
    }
    public static DateTime IngresarFecha(string msj){
        DateTime n;
        while(!DateTime.TryParse(IngresarStr(msj), out n)){
            Console.WriteLine("El ingreso no es valido, ingrese de nuevo con formato: DD/MM/AAAA:");
        }
        return n;
    }
    public static double IngresarDecimal(string msj){
        double n;
        Console.WriteLine(msj);
        while(!double.TryParse(Console.ReadLine(),out n)){
            Console.WriteLine("El ingreso no es un numero, intente otra vez:");
        }
        return n;
        
    }
    public static void PresionaParaContinuar(){
        Console.WriteLine("Presiona Enter para Continuar");
        Console.ReadLine();
    }

}
    