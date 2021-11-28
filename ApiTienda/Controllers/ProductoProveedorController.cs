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
    public class ProductoProveedorController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductoProveedorController(AppDbContext context)
        {
            this.context = context;
        }



        // GET: api/<ProductoProveedorController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.ProductoProveedor.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // GET api/<ProductoProveedorController>/5
        [HttpGet("{id}", Name = "GetProductoProveedor")]
        public ActionResult Get(int id)
        {
            try
            {
                var ProductoProveedor = context.ProductoProveedor.FirstOrDefault(p => p.idProductoProveedor == id);
                return Ok(ProductoProveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // POST api/<ProductoProveedorController>
        [HttpPost]
        public ActionResult Post([FromBody] ProductoProveedor ProductoProveedor)
        {
            try
            {
                context.ProductoProveedor.Add(ProductoProveedor);
                context.SaveChanges();
                return CreatedAtRoute("GetProductoProveedor", new { id = ProductoProveedor.idProductoProveedor }, ProductoProveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // PUT api/<ProductoProveedorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProductoProveedor ProductoProveedor)
        {
            try
            {
                if (ProductoProveedor.idProductoProveedor == id)
                {
                    context.Entry(ProductoProveedor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProductoProveedor", new { id = ProductoProveedor.idProductoProveedor }, ProductoProveedor);
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






        // DELETE api/<ProductoProveedorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var ProductoProveedor = context.ProductoProveedor.FirstOrDefault(p => p.idProductoProveedor == id);

                if (ProductoProveedor != null)
                {
                    context.ProductoProveedor.Remove(ProductoProveedor);
                    context.SaveChanges();

                    return Ok(ProductoProveedor);
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
