using backend_especial.Models;
using System.Collections.Generic;


namespace backend_especial.Iservice
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
