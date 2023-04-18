public static class Funciones{
    public static int IngresarEntero(string msj){
        int n;
        Console.WriteLine(msj);
        while(int.TryParse(Console.ReadLine(),out n)){
            Console.WriteLine("El numero ingresado no es un entero, intente otra vez:");
        }
        return n;
    }
    public static string IngresarStr(string msj){
        Console.WriteLine(msj);
        string s = Console.ReadLine();
        while(s == null){
            Console.WriteLine("El ingreso fue nulo, ingrese de nuevo");
            s = Console.ReadLine();
        }
        return s;
    }
    public static int IngresarEnteroConRango(string msj, int min, int max){
        int n = IngresarEntero(msj);
        while(n < min || n > max){
            Console.WriteLine("El ingreso esta fuera del rango aceptado, ingresá de nuevo");
            n = IngresarEntero("");
        }
        return n;
    }

}
    