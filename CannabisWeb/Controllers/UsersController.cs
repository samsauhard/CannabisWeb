using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CannabisWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CannabisWeb.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private readonly cannabis_dataContext _context;

        public UsersController(cannabis_dataContext context)
        {
            _context = context;
        }


        [HttpGet("/api/users.{format}"), FormatFilter]
        public IEnumerable<User> Get()
        {
            return _context.User;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IEnumerable<User> Get(int id)
        {
            yield return _context.User.Find(id);
        }

        // POST api/<controller>
        //[HttpPost]
        [HttpPost("/api/users.{format}"), FormatFilter]
        public String Post([FromBody]User cannabis)
        {
            User cannabisdata = new User();
            _context.User.Add(new User { Id = cannabis.Id, FName = cannabis.FName, LName = cannabis.LName, Email = cannabis.Email, Phone = cannabis.Phone });
            _context.SaveChangesAsync();
            return "Success";

        }

        // PUT api/<controller>/5
        [HttpPut("/api/users.{format}"), FormatFilter]
        public void Put(int id, [FromBody]User value)
        {
            var existingTypes = _context.User.Where(s => s.Id == value.Id)
                                                   .FirstOrDefault<User>();

            if (existingTypes != null)
            {
                if (value.FName != null)
                    existingTypes.FName = value.FName;
                if (value.LName != null)
                    existingTypes.LName = value.LName;
                if (value.Email != null)
                    existingTypes.Email = value.Email;
                if (value.Phone != null)
                    existingTypes.Phone = value.Phone;

                _context.SaveChanges();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var type = _context.User
               .Where(s => s.Id == id)
               .FirstOrDefault();

            _context.Remove(type);
            _context.SaveChanges();
        }
    }
}
