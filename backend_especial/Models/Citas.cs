namespace backend_especial.Models
{
    public class Citas
    {
        public int Id_cita { get; set; }
        public string Fecha { get; set; }
        public int hora { get; set; }
        public int Id_Usuario { get; set; }
        public int Psicologo { get; set; }
        public int Municipio { get; set; }
        public string Error { get; set; }
    }
}
