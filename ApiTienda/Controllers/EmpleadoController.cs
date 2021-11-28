using ApiTienda.Context;
using ApiTienda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly AppDbContext context;

        public EmpleadoController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<EmpleadoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Empleado.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{id}", Name = "GetEmpleado")]
        public ActionResult Get(int id)
        {
            try
            {
                var Empleado = context.Empleado.FirstOrDefault(p => p.idEmpleado == id);
                return Ok(Empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public ActionResult Post([FromBody] Empleado Empleado)
        {
            try
            {
                context.Empleado.Add(Empleado);
                context.SaveChanges();
                return CreatedAtRoute("GetEmpleado", new { id = Empleado.idEmpleado }, Empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Empleado Empleado)
        {
            try
            {
                if (Empleado.idEmpleado == id)
                {
                    context.Entry(Empleado).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetEmpleado", new { id = Empleado.idEmpleado }, Empleado);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var Empleado = context.Empleado.FirstOrDefault(p => p.idEmpleado == id);

                if (Empleado != null)
                {
                    context.Empleado.Remove(Empleado);
                    context.SaveChanges();

                    return Ok(Empleado);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
