using backend_especial.Models;
using System.Collections.Generic;


namespace backend_especial.Iservice
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
