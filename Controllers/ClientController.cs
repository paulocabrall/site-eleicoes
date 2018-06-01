using System;
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
            return _ctx.Clients.OrderByDescending(x => x.CreatedAt).ToList();
        }
        
        [HttpGet("{clientId}")]
        public ActionResult<Client> FindClientById(string clientId)
        {
            if (clientId == "new") return new Client();

            var isIdANumber = int.TryParse(clientId, out var id);
            if (!isIdANumber) return NotFound();
            
            var client = _ctx.Clients.FirstOrDefault(x => x.Id == id);
            if (client == null) return NotFound();
            
            return Ok(client);
        }
        
        [HttpPost("")]
        public ActionResult<Client> SaveClient([FromBody] Client c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            c.Id = default(int);
            c.CreatedAt = DateTime.UtcNow;
            c.UpdatedAt = DateTime.UtcNow;
            
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

            var existingClient = _ctx.Clients.FirstOrDefault(x => x.Id == clientId);
            if (existingClient == null) return NotFound();

            existingClient.UpdatedAt = DateTime.UtcNow;
            existingClient.Name = c.Name;
            existingClient.Address = c.Address;
            existingClient.AddressComplement = c.AddressComplement;
            existingClient.Email = c.Email;
            existingClient.Notes = c.Notes;
            existingClient.PhoneNumber = c.PhoneNumber;
            existingClient.ZipCode = c.ZipCode;
            
            _ctx.Clients.Update(existingClient);
            _ctx.SaveChanges();

            return c;
        }

        [HttpDelete("{clientId}")]
        public ActionResult<Client> RemoveClient(string clientId)
        {
            var isIdANumber = int.TryParse(clientId, out var id);
            if (!isIdANumber) return NotFound();
            
            var client = _ctx.Clients.FirstOrDefault(x => x.Id == id);
            if (client == null) return NotFound();

            _ctx.Clients.Remove(client);
            _ctx.SaveChanges();
            
            return Ok(client);
        }
        
    }
}