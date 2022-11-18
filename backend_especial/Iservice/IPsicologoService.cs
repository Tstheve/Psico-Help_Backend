using backend_especial.Models;
using System.Collections.Generic;



namespace backend_especial.Iservice
{
    public interface IPsicologoService
    {
        Psicologo AddPsicologo(Psicologo oPsicologo);
        List<Psicologo> GetsPsicologo();
        Psicologo GetByPsicologoId(int PsicologoID);
        string DeletePsicologo(int PsicologoID);
        Psicologo UpdatePsicologo(Psicologo oPsicologo);


    }
}
