using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using Model;

namespace ProyectoAPI.Controllers
{
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _clienteService.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _clienteService.Get(id)
                );
        }

        // POST api/values
        [HttpPost]
        public  IActionResult Post([FromBody] Cliente model)
        {
            return Ok(
                _clienteService.Add(model)
            );

        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Cliente model)
        {
            return Ok(
                _clienteService.Add(model)
                );

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
               _clienteService.Delete(id)
               );

        }
    }
}
