using BackEnd_Proyecto.Models;
using System.Collections.Generic;

namespace BackEnd_Proyecto.IService
{
    public interface IMembresiaService
    {
        Membresia AddMembresia(Membresia oMembresia);
        List<Membresia> GetsMembresia();
        Membresia GetByMembresiaId(int MembresiaID);
        string DeleteMembresia(int MembresiaID);
        Membresia UpdateMembresia(Membresia oMembresia);
    }
}
