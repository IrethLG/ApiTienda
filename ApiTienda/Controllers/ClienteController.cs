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
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext context;

        public ClienteController(AppDbContext context)
        {
            this.context = context;
        }



        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Cliente.ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}",Name ="GetCliente")]
        public ActionResult Get(int id)
        {
            try
            {
                var cliente = context.Cliente.FirstOrDefault(p => p.idCliente == id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente Cliente)
        {
            try
            {
                context.Cliente.Add(Cliente);
                context.SaveChanges();
                return CreatedAtRoute("GetCliente", new {id =Cliente.idCliente },Cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente Cliente)
        {
            try
            {
                if(Cliente.idCliente==id)
                {
                context.Entry(Cliente).State=EntityState.Modified;
                context.SaveChanges();
                return CreatedAtRoute("GetCliente", new { id = Cliente.idCliente }, Cliente);
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

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {                   
                var cliente = context.Cliente.FirstOrDefault(p => p.idCliente == id);

                if (cliente != null)
                {
                    context.Cliente.Remove(cliente);
                    context.SaveChanges();

                    return Ok(cliente);
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
