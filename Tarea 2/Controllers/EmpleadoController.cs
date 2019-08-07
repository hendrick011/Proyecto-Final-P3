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
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _empleadoService.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _empleadoService.Get(id)
                );
        }

        // POST api/values
        [HttpPost]
        public  IActionResult Post([FromBody] Empleado model)
        {
            return Ok(
                _empleadoService.Add(model)
            );

        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Empleado model)
        {
            return Ok(
                _empleadoService.Add(model)
                );

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
               _empleadoService.Delete(id)
               );

        }
    }
}
