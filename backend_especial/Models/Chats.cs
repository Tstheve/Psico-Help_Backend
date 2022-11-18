namespace backend_especial.Models
{
    public class Chats
    {
        public int Id_Chat { get; set; }
        public int Id_Usuario { get; set; }
        public string Asunto { get; set; }

        public int  Id_Psicologo { get; set; }
        public string Error { get; set; }
    }
}
