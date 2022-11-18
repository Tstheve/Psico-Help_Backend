using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend_especial.Iservice;
using backend_especial.Models;
using System.Collections.Generic;

namespace backend_especial.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PsicologoController : ControllerBase
    {
        private IPsicologoService _oPsicoloService;
        public PsicologoController(IPsicologoService oPsicologoService)
        {
            _oPsicoloService = oPsicologoService;
        }


        // GET: api/<PsicologoController>
        [HttpGet]
        public IEnumerable<Psicologo> Get()
        {
            return _oPsicoloService.GetsPsicologo();
        }
        // GET api/<PsicologoController>/5
        [HttpGet("{id}", Name = "GetPsicologoId")]
        public Psicologo GetPsicologoId(int id)
        {
            return _oPsicoloService.GetByPsicologoId(id);
        }

        // POST api/<ChatsController>
        [HttpPost]
        public void PostPsicologo([FromBody] Psicologo oPsicologo)
        {
            if (ModelState.IsValid) _oPsicoloService.AddPsicologo(oPsicologo);
        }

        // PUT api/<PsicologoController>/5
        [HttpPut]
        public void PutPsicologo([FromBody] Psicologo oPsicologo)
        {
            if (ModelState.IsValid) _oPsicoloService.UpdatePsicologo(oPsicologo);
        }

        // DELETE api/<PsicologoController>/5
        [HttpDelete("{id}")]
        public void DeletePsicologo(int id)
        {
            if (id != 0) _oPsicoloService.DeletePsicologo(id);
        }


    }
}
