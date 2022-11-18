using backend_especial.Models;
using System.Collections.Generic;


namespace backend_especial.Iservice
{
    public interface ICitasService
    {
        Citas AddCitas(Citas oCitas);
        List<Citas> GetsCitas();
        Citas GetByCitasId(int CitasID);
        string DeleteCitas(int CitasID);
        Citas UpdateCitas(Citas oCitas);


    }
}
