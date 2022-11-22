using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_Proyecto.Models
{
    public class Psicologo
    {
        public int Id_Psicologo { get; set; }
        public int Id_Usuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public string Especialidad { get; set; }

        public int Años_de_experiencia { get; set; }
        public string Error { get; set; }

    }
}
