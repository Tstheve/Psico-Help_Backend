using BackEnd_Proyecto.Models;
using System.Collections.Generic;

namespace BackEnd_Proyecto.IService
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
