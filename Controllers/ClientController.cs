using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using banze.Core;
using Microsoft.AspNetCore.Mvc;

namespace banze.Controllers
{
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _ctx;

        public ClientController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        
        [HttpGet("")]
        public IEnumerable<Client> FindAllClients()
        {
            return _ctx.Clients.ToList();
        }
        
        [HttpPost("")]
        public ActionResult<Client> SaveClient([FromBody] Client c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _ctx.Clients.Add(c);
            _ctx.SaveChanges();

            return c;
        }
        
        [HttpPut("{clientId}")]
        public ActionResult<Client> UpdateClient([Required] int clientId, [FromBody] Client c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _ctx.Clients.Update(c);
            _ctx.SaveChanges();

            return c;
        }


    }
}