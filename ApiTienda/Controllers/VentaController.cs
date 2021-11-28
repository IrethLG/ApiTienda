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
    public class VentaController : ControllerBase
    {
        private readonly AppDbContext context;

        public VentaController(AppDbContext context)
        {
            this.context = context;
        }



        // GET: api/<VentaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Venta.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        // GET api/<VentaController>/5
        [HttpGet("{id}", Name = "GetVenta")]
        public ActionResult Get(int id)
        {
            try
            {
                var Venta = context.Venta.FirstOrDefault(p => p.idVenta == id);
                return Ok(Venta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // POST api/<VentaController>
        [HttpPost]
        public ActionResult Post([FromBody] Venta Venta)
        {
            try
            {
                context.Venta.Add(Venta);
                context.SaveChanges();
                return CreatedAtRoute("GetVenta", new { id = Venta.idVenta }, Venta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // PUT api/<VentaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Venta Venta)
        {
            try
            {
                if (Venta.idVenta == id)
                {
                    context.Entry(Venta).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetVenta", new { id = Venta.idCliente }, Venta);
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




        // DELETE api/<VentaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var Venta = context.Venta.FirstOrDefault(p => p.idVenta == id);

                if (Venta != null)
                {
                    context.Venta.Remove(Venta);
                    context.SaveChanges();

                    return Ok(Venta);
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
