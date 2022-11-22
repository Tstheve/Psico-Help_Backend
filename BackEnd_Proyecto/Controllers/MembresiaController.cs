using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd_Proyecto.IService;
using BackEnd_Proyecto.Models;
using System.Collections.Generic;


namespace BackEnd_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembresiaController : ControllerBase
    {
        private IMembresiaService _oMembresiaService;

        public MembresiaController(IMembresiaService oMembresiaService)
        {
            _oMembresiaService = oMembresiaService;
        }
        // GET: api/<MembresiaController>
        [HttpGet]
        public IEnumerable<Membresia> Get()
        {
            return _oMembresiaService.GetsMembresia();
        }
        // GET api/<MembresiaController>/5
        [HttpGet("{id}", Name = "GetMembresiaId")]
        public Membresia GetMembresiaId(int id)
        {
            return _oMembresiaService.GetByMembresiaId(id);
        }

        // POST api/<MembresiaController>
        [HttpPost]
        public void PostMembresia([FromBody] Membresia oMembresia)
        {
            if (ModelState.IsValid) _oMembresiaService.AddMembresia(oMembresia);
        }

        // PUT api/<MembresiaController>/5
        [HttpPut]
        public void PutMembresia([FromBody] Membresia oMembresia)
        {
            if (ModelState.IsValid) _oMembresiaService.UpdateMembresia(oMembresia);
        }

        // DELETE api/<MembresiaController>/5
        [HttpDelete("{id}")]
        public void DeleteMembresia(int id)
        {
            if (id != 0) _oMembresiaService.DeleteMembresia(id);
        }
    }
}
