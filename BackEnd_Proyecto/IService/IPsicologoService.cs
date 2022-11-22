using BackEnd_Proyecto.Models;
using System.Collections.Generic;

namespace BackEnd_Proyecto.IService
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
