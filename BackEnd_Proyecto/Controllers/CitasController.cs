using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd_Proyecto.IService;
using BackEnd_Proyecto.Models;
using System.Collections.Generic;


namespace BackEnd_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private ICitasService _oCitasService;

        public CitasController(ICitasService oCitasService)
        {
            _oCitasService = oCitasService;
        }
        // GET: api/<CitasController>
        [HttpGet]
        public IEnumerable<Citas> Get()
        {
            return _oCitasService.GetsCitas();
        }
        // GET api/<CitasController>/5
        [HttpGet("{id}", Name = "GetCitasId")]
        public Citas GetCitasId(int id)
        {
            return _oCitasService.GetByCitasId(id);
        }

        // POST api/<CitasController>
        [HttpPost]
        public void PostCitas([FromBody] Citas oCitas)
        {
            if (ModelState.IsValid) _oCitasService.AddCitas(oCitas);
        }

        // PUT api/<Controller>/5
        [HttpPut]
        public void PutCitas([FromBody] Citas oCitas)
        {
            if (ModelState.IsValid) _oCitasService.UpdateCitas(oCitas);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void DeleteCitas(int id)
        {
            if (id != 0) _oCitasService.DeleteCitas(id);
        }
    }
}
