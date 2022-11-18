namespace backend_especial.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }

        public string Correo { get; set; }

        public string Clave { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
        public string Pseudonimo { get; set; }
        public string Error { get; set; }

    }
}
