public static class Tiquetera{
    private static Dictionary<int, Cliente> DicClientes = new Dictionary<int, Cliente>();
    private static int UltimoIDEntrada = 1;

    public static int DevolverUltimoID(){
        return UltimoIDEntrada;
    }
    public static int AgregarCliente(Cliente c){
        DicClientes.Add(UltimoIDEntrada, c);
        int id = UltimoIDEntrada;
        UltimoIDEntrada++;
        return id;
    }
    public static Cliente BuscarCliente(int IDEntrada){
        Cliente c = DicClientes[IDEntrada];
        return c;
    }
    public static bool CambiarEntrada(int id, int tipo, double total){
        if(DicClientes[id].TotalAbonado<total){
            DicClientes[id].TipoEntrada = tipo;
            return true;
        }
        else return false;
    }
    public static List<string> EstadisticasTiquetera(){
        List<string> Estadisticas = new List<string>();
        //0 Total Clientes
        Estadisticas.Add(DicClientes.Count.ToString());
        double sumatipo1 = 0, sumatipo2 = 0, sumatipo3 = 0, sumatipo4 = 0;
        int tipo1 = 0, tipo2 = 0, tipo3 = 0, tipo4 = 0;
        foreach(KeyValuePair<int ,Cliente> entry in DicClientes){
            switch(entry.Value.TipoEntrada){
                case 1:
                    tipo1++;
                    sumatipo1 += entry.Value.TotalAbonado;
                break;
                case 2:
                    tipo2++;
                    sumatipo2 += entry.Value.TotalAbonado;
                break;
                case 3:
                    tipo3++;
                    sumatipo3 += entry.Value.TotalAbonado;
                break;
                case 4:
                    tipo4++;
                    sumatipo4 += entry.Value.TotalAbonado;
                break;
            }
        }
        int totaltipos = tipo1+tipo2+tipo3+tipo4;
        //1,4 Porcentaje cada dia x entrada
        Estadisticas.Add((tipo1/totaltipos*100).ToString());Estadisticas.Add((tipo2/totaltipos*100).ToString());Estadisticas.Add((tipo3/totaltipos*100).ToString());Estadisticas.Add((tipo4/totaltipos*100).ToString());
        //5,8 Suma $ cada dia
        Estadisticas.Add(sumatipo1.ToString());Estadisticas.Add(sumatipo2.ToString());Estadisticas.Add(sumatipo3.ToString());Estadisticas.Add(sumatipo4.ToString());
        
        double sumaTotal = 0;
        foreach(KeyValuePair<int ,Cliente> entry in DicClientes){
            sumaTotal += entry.Value.TotalAbonado;
        }
        //9 Total Recaudado
        Estadisticas.Add(sumaTotal.ToString());
        return Estadisticas;
    }

}