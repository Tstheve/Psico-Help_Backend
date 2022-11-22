using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BackEnd_Proyecto.Models
{
    public class Chats
    {
        public int Id_Chat { get; set; }

        public int Id_Usuario { get; set; }

        public string Asunto { get; set; }
        public int Id_Psicologo { get; set; }

        public string Error { get; set; }
    }
}
