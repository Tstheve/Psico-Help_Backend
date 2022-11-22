using BackEnd_Proyecto.Models;
using System.Collections.Generic;

namespace BackEnd_Proyecto.IService
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
