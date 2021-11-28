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
    public class ProveedorController : ControllerBase
    {

        private readonly AppDbContext context;

        public ProveedorController(AppDbContext context)
        {
            this.context = context;
        }



        // GET: api/<ProveedorController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Proveedor.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        // GET api/<ProveedorController>/5
        [HttpGet("{id}", Name = "GetProveedor")]
        public ActionResult Get(int id)
        {
            try
            {
                var Proveedor = context.Proveedor.FirstOrDefault(p => p.idProveedor == id);
                return Ok(Proveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // POST api/<ProveedorController>
        [HttpPost]
        public ActionResult Post([FromBody] Proveedor Proveedor)
        {
            try
            {
                context.Proveedor.Add(Proveedor);
                context.SaveChanges();
                return CreatedAtRoute("GetProveedor", new { id = Proveedor.idProveedor }, Proveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // PUT api/<ProveedorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Proveedor Proveedor)
        {
            try
            {
                if (Proveedor.idProveedor == id)
                {
                    context.Entry(Proveedor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProveedor", new { id = Proveedor.idProveedor }, Proveedor);
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





        // DELETE api/<ProveedorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var Proveedor = context.Proveedor.FirstOrDefault(p => p.idProveedor == id);

                if (Proveedor != null)
                {
                    context.Proveedor.Remove(Proveedor);
                    context.SaveChanges();

                    return Ok(Proveedor);
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
