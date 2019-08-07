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
    public class CompraController : Controller
    {
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _compraService.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _compraService.Get(id)
                );
        }

        // POST api/values
        [HttpPost]
        public  IActionResult Post([FromBody] Compra model)
        {
            return Ok(
                _compraService.Add(model)
            );

        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Compra model)
        {
            return Ok(
                _compraService.Add(model)
                );

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
               _compraService.Delete(id)
               );

        }
    }
}
