using BackEnd_Proyecto.Models;
using System.Collections.Generic;

namespace BackEnd_Proyecto.IService
{
    public interface IMunicipioService
    {
        Municipio AddMunicipio(Municipio oMunicipio);
        List<Municipio> GetsMunicipio();
        Municipio GetByMunicipioId(int MunicipioID);
        string DeleteMunicipio(int MunicipioID);
        Municipio UpdateMunicipio(Municipio oMunicipio);
    }
}
