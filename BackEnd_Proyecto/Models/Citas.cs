using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BackEnd_Proyecto.Models
{
    public class Citas
    {
        public int Id_Cita { get; set; }

        public DateTime Fecha { get; set; }

        public int Id_Usuario { get; set; }

        public int Id_Psicologo { get; set; }

        public int Id_Municipio { get; set; }
        public string Error     { get; set; }
    }
}
