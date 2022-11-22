using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BackEnd_Proyecto.Models
{
    public class Membresia
    {
        public int Id_Membresia { get; set; }

        public string Descripcion { get; set; }

        public string Precio { get; set; }

        public int Id_Usuario { get; set; }
        public string Error { get; set; }

    }
}
