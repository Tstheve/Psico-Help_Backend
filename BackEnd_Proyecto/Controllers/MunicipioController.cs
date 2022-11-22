using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd_Proyecto.IService;
using BackEnd_Proyecto.Models;
using System.Collections.Generic;


namespace BackEnd_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private IMunicipioService _oMunicipioService;

        public MunicipioController(IMunicipioService oMunicipioService)
        {
            _oMunicipioService = oMunicipioService;
        }
        // GET: api/<MunicipioController>
        [HttpGet]
        public IEnumerable<Municipio> Get()
        {
            return _oMunicipioService.GetsMunicipio();
        }
        // GET api/<MunicipioController>/5
        [HttpGet("{id}", Name = "GetMunicipioId")]
        public Municipio GetMunicipioId(int id)
        {
            return _oMunicipioService.GetByMunicipioId(id);
        }

        // POST api/<MunicipioController>
        [HttpPost]
        public void PostMunicipio([FromBody] Municipio oMunicipio)
        {
            if (ModelState.IsValid) _oMunicipioService.AddMunicipio(oMunicipio);
        }

        // PUT api/<MunicipioController>/5
        [HttpPut]
        public void PutMunicipio([FromBody] Municipio oMunicipio)
        {
            if (ModelState.IsValid) _oMunicipioService.UpdateMunicipio(oMunicipio);
        }

        // DELETE api/<MunicipioController>/5
        [HttpDelete("{id}")]
        public void DeleteMunicipio(int id)
        {
            if (id != 0) _oMunicipioService.DeleteMunicipio(id);
        }
    }
}
