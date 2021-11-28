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
    public class ProductoVentaController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductoVentaController(AppDbContext context)
        {
            this.context = context;
        }


        // GET: api/<ProductoVentaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.ProductoVenta.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // GET api/<ProductoVentaController>/5
        [HttpGet("{id}", Name = "GetProductoVenta")]
        public ActionResult Get(int id)
        {
            try
            {
                var ProductoVenta = context.ProductoVenta.FirstOrDefault(p => p.idProductoVenta == id);
                return Ok(ProductoVenta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        // POST api/<ProductoVentaController>
        [HttpPost]
        public ActionResult Post([FromBody] ProductoVenta ProductoVenta)
        {
            try
            {
                context.ProductoVenta.Add(ProductoVenta);
                context.SaveChanges();
                return CreatedAtRoute("GetProductoVenta", new { id = ProductoVenta.idProductoVenta }, ProductoVenta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        // PUT api/<ProductoVentaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProductoVenta ProductoVenta)
        {
            try
            {
                if (ProductoVenta.idProductoVenta == id)
                {
                    context.Entry(ProductoVenta).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProductoVenta", new { id = ProductoVenta.idProductoVenta }, ProductoVenta);
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






        // DELETE api/<ProductoVentaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var ProductoVenta = context.ProductoVenta.FirstOrDefault(p => p.idProductoVenta == id);

                if (ProductoVenta != null)
                {
                    context.ProductoVenta.Remove(ProductoVenta);
                    context.SaveChanges();

                    return Ok(ProductoVenta);
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
