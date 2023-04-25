const int SALIR = 5;
const string CLIENTE_DNI = "Ingrese su DNI",  CLIENTE_APELLIDO = "Ingrese su Apellido", CLIENTE_NOMBRE = "Ingrese su Nombre", CLIENTE_FECHA = "Ingrese la fecha de hoy en formato DD/MM/AAAA", CLIENTE_ENTRADA = "Ingrese que tipo de entrada quiere:\nEntrada día 1: 15000\nEntrada día 2: 30000\nEntrada día 3: 10000\nEntrada día 4: 40000", CLIENTE_ABONADO = "Ingrese cuanto va a abonar";
const double ENTRADA1 = 15000, ENTRADA2 = 30000, ENTRADA3 = 10000, ENTRADA4 = 40000;
int opcion = Funciones.IngresarEnteroConRango("Ingresa una opción\n1: Inscripción\n2: Estadísticas\n3: Buscar Cliente\n4: Cambiar Entrada de Cliente\n5: Salir",1,5);
while(opcion != SALIR){
switch(opcion){
    case 1:
        Cliente cliente1 = new Cliente(Funciones.IngresarEntero(CLIENTE_DNI), Funciones.IngresarStr(CLIENTE_APELLIDO), Funciones.IngresarStr(CLIENTE_NOMBRE), Funciones.IngresarFecha(CLIENTE_FECHA), Funciones.IngresarEnteroConRango(CLIENTE_ENTRADA, 1, 4), Funciones.IngresarDecimal(CLIENTE_ABONADO));
        double totalAbonar = 0;
        switch(cliente1.TipoEntrada){
            case 1:
            totalAbonar = ENTRADA1;
            break;
            case 2:
            totalAbonar = ENTRADA2;
            break;
            case 3:
            totalAbonar = ENTRADA3;
            break;
            case 4:
            totalAbonar = ENTRADA4;
            break;
        }
        while(totalAbonar > cliente1.TotalAbonado){
            cliente1.TipoEntrada = Funciones.IngresarEnteroConRango("El total abonado es menor al debido, ingrese de vuelta:\nEntrada día 1: 15000\nEntrada día 2: 30000\nEntrada día 3: 10000\nEntrada día 4: 40000", 1, 4); 
            cliente1.TotalAbonado = Funciones.IngresarDecimal(CLIENTE_ABONADO);
            switch(cliente1.TipoEntrada){
            case 1:
            totalAbonar = ENTRADA1;
            break;
            case 2:
            totalAbonar = ENTRADA2;
            break;
            case 3:
            totalAbonar = ENTRADA3;
            break;
            case 4:
            totalAbonar = ENTRADA4;
            break;
        }
        }
        if(totalAbonar<cliente1.TotalAbonado){
            Console.WriteLine("Ingresó plata demás, se le devolverán " + (cliente1.TotalAbonado - totalAbonar).ToString());
            cliente1.TotalAbonado = totalAbonar;
        }
        Console.WriteLine("El ID de cliente es "+Tiquetera.AgregarCliente(cliente1));
    break;
    case 2:
        MostrarEstadísticas(Tiquetera.EstadisticasTiquetera());
    break;
    case 3:
        int idBuscar = Funciones.IngresarEntero("Ingresa el ID del cliente que quieras buscar");
        Cliente buscado = Tiquetera.BuscarCliente(idBuscar);
        Console.WriteLine("*DNI: " + buscado.DNI);
        Console.WriteLine("*Apellido: " + buscado.Apellido);
        Console.WriteLine("*Nombre: " + buscado.Nombre);
        Console.WriteLine("*Fecha de inscripcion: " + buscado.FechaInscripcion.ToShortDateString());
        Console.WriteLine("*Tipo de entrda: " + buscado.TipoEntrada);
        Console.WriteLine("*Total abonado: " + buscado.TotalAbonado);

    break;
    case 4:
        idBuscar = Funciones.IngresarEntero("Ingresa el ID del cliente que quieras modificar");
        buscado = Tiquetera.BuscarCliente(idBuscar);
        int tipo = Funciones.IngresarEnteroConRango("Ingresa el tipo de entrada al que quieras cambiar",1,4);
        double precioEntrada = 0;
        switch(tipo){
            case 1:
            precioEntrada = ENTRADA1;
            break;
            case 2:
            precioEntrada = ENTRADA2;
            break;
            case 3:
            precioEntrada = ENTRADA3;
            break;
            case 4:
            precioEntrada = ENTRADA4;
            break;
        }
        while(!Tiquetera.CambiarEntrada(idBuscar,tipo,precioEntrada)){
            Console.WriteLine("No se pudo cambiar la entrada, el precio de esta debe ser mayor a de la anterior");
            tipo = Funciones.IngresarEnteroConRango("Ingresa el tipo de entrada al que quieras cambiar",1,4);
            precioEntrada = 0;
            switch(tipo){
                case 1:
                    precioEntrada = ENTRADA1;
                break;
                case 2:
                    precioEntrada = ENTRADA2;
                break;
                case 3:
                    precioEntrada = ENTRADA3;
                break;
                case 4:
                    precioEntrada = ENTRADA4;
                break;
            }
        }
        Console.WriteLine("Tendrás que agregar $"+(precioEntrada - buscado.TotalAbonado));
        buscado.TipoEntrada = tipo;
        buscado.TotalAbonado = precioEntrada;
        buscado.FechaInscripcion = DateTime.Today;
        Tiquetera.ActualizarCliente(idBuscar, buscado);
    break;
}
Funciones.PresionaParaContinuar();
opcion = Funciones.IngresarEnteroConRango("Ingresa una opción\n1: Inscripción\n2: Estadísticas\n3: Buscar Cliente\n4: Cambiar Entrada de Cliente\n5: Salir",1,5);
Console.Clear();
}
static void MostrarEstadísticas(List<string> l){
    Console.WriteLine("El total de clientes fue: "+l[0].ToString());
    Console.WriteLine("El "+l[1].ToString()+"% de las entradas vendidas fueron del dia 1");
    Console.WriteLine("El "+l[2].ToString()+"% de las entradas vendidas fueron del dia 2");
    Console.WriteLine("El "+l[3].ToString()+"% de las entradas vendidas fueron del dia 3");    
    Console.WriteLine("El "+l[4].ToString()+"% de las entradas vendidas fueron del dia 4");
    Console.WriteLine("El dia 1 se recaudo: $" + l[5].ToString());
    Console.WriteLine("El dia 2 se recaudo: $" + l[6].ToString());
    Console.WriteLine("El dia 3 se recaudo: $" + l[7].ToString());
    Console.WriteLine("El dia 4 se recaudo: $" + l[8].ToString());
    Console.WriteLine("El total recaudado es: $" + l[9].ToString());
}

