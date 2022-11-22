using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd_Proyecto.IService;
using BackEnd_Proyecto.Models;
using System.Collections.Generic;


namespace BackEnd_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _oUsuarioService;

        public UsuarioController(IUsuarioService oUsuarioService)
        {
            _oUsuarioService = oUsuarioService;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _oUsuarioService.GetsUsuario();
        }
        // GET api/<UsuarioController>/5
        [HttpGet("{Id_Usuario}", Name = "GetUsuarioId")]
        public Usuario GetUsuarioId(int id)
        {
            return _oUsuarioService.GetByUsuarioId(id);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void PostUsuario([FromBody] Usuario oUsuario)
        {
            if (ModelState.IsValid) _oUsuarioService.AddUsuario(oUsuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public void PutUsuario([FromBody] Usuario oUsuario)
        {
            if (ModelState.IsValid) _oUsuarioService.UpdateUsuario(oUsuario);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{Id_Usuario}")]
        public void DeleteUsuario(int id)
        {
            if (id != 0) _oUsuarioService.DeleteUsuario(id);
        }
    }
}
