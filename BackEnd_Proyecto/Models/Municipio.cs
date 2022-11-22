using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_Proyecto.Models
{
    public class Municipio
    {
        public int Id_Municipio { get; set; }

        public string Nombre_Municipio { get; set; }

        public string Departamento { get; set; }

        public int Id_Usuario { get; set; }

        public string Error { get; set; }
    }
}
