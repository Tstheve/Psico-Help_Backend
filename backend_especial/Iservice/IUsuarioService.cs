using backend_especial.Models;
using System.Collections.Generic;



namespace backend_especial.Iservice
{
    public interface IUsuarioService
    {
        Usuario AddUsuario(Usuario oUsuario);
        List<Usuario> GetsUsuario();
        Usuario GetByUsuarioId(int UsuarioID);
        string DeleteUsuario(int UsuarioID);
        Usuario UpdateUsuario(Usuario oUsuario);
    }
}
