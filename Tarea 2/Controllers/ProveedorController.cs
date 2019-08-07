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
    public class ProveedorController : Controller
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _proveedorService.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _proveedorService.Get(id)
                );
        }

        // POST api/values
        [HttpPost]
        public  IActionResult Post([FromBody] Proveedor model)
        {
            return Ok(
                _proveedorService.Add(model)
            );

        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Proveedor model)
        {
            return Ok(
                _proveedorService.Add(model)
                );

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
               _proveedorService.Delete(id)
               );

        }
    }
}
