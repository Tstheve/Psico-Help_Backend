using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_Proyecto.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }

        public string Correo { get; set; }

        public string Clave { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public string Telefono { get; set; }

        public string Pseudonimo { get; set; }
        public string Error { get; set; }

    }
}
