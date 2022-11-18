namespace backend_especial.Models
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
