using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd_Proyecto.IService;
using BackEnd_Proyecto.Models;
using System.Collections.Generic;


namespace BackEnd_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private IChatsService _oChastService;

        public ChatsController(IChatsService oChatsService)
        {
            _oChastService = oChatsService;
        }



        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<Chats> Get()
        {
            return _oChastService.GetsChats();
        }
        // GET api/<ChatsController>/5
        [HttpGet("{id}", Name = "GetChatsId")]
        public Chats GetChatsId(int id)
        {
            return _oChastService.GetByChatId(id);
        }

        // POST api/<ChatsController>
        [HttpPost]
        public void PostChats([FromBody] Chats oChats)
        {
            if (ModelState.IsValid) _oChastService.AddChats(oChats);
        }

        // PUT api/<ChatsController>/5
        [HttpPut]
        public void PutChats([FromBody] Chats oChats)
        {
            if (ModelState.IsValid) _oChastService.UpdateChats(oChats);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void DeleteChats(int id)
        {
            if (id != 0) _oChastService.DeleteChats(id);
        }

    }
}
