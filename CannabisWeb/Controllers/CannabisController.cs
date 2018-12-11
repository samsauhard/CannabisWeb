using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using CannabisWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CannabisWeb.Controllers
{
    
    [Route("api/[controller]")]
    public class CannabisController : Controller
    {

        private readonly cannabis_dataContext _context;

        public CannabisController(cannabis_dataContext context)
        {
            _context = context;
        }
        /*
                // GET: api/Cannabis
                [HttpGet]
                public IEnumerable<Types> GetCannabisItems()
                {
                    return _context.Types;
                }
                [HttpGet]
                public async Task<ActionResult<IEnumerable<Types>>>getData()
                {
                    return await _context.Types.ToListAsync();
                }
                */
        // GET: api/<controller>
        
        [HttpGet("/api/cannabis.{format}"), FormatFilter]
        public IEnumerable<Types> Get()
        {
            return _context.Types;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IEnumerable<Types> Get(int id)
        {
            yield return _context.Types.Find(id);
        }

        // POST api/<controller>
        //[HttpPost]
        [HttpPost("/api/cannabis.{format}"), FormatFilter]
        public String Post([FromBody]Types cannabis)
        {
            Types cannabisdata = new Types();
            _context.Types.Add(new Types { Id = cannabis.Id, Name = cannabis.Name, PostedBy = cannabis.PostedBy, PostedDate = DateTime.Now,Thc = cannabis.Thc, Cbd = cannabis.Cbd, High = cannabis.High, EaseMigraine= cannabis.EaseMigraine, IncreaseApetite= cannabis.IncreaseApetite, PainReliever= cannabis.PainReliever, ReduceAnxiety= cannabis.ReduceAnxiety, SideEffects= cannabis.SideEffects});
            _context.SaveChangesAsync();
            return "Success";

        }

        // PUT api/<controller>/5
        [HttpPut("/api/cannabis.{format}"), FormatFilter]
        public void Put(int id, [FromBody]Types value)
        {
            var existingTypes = _context.Types.Where(s => s.Id == value.Id)
                                                   .FirstOrDefault<Types>();

            if (existingTypes != null)
            {
                if(value.Name != null)
                    existingTypes.Name = value.Name;
                if (value.Thc != null)
                    existingTypes.Thc = value.Thc;
                if (value.Type != null)
                    existingTypes.Type = value.Type;
                if (value.Cbd != null)
                    existingTypes.Cbd = value.Cbd;
                if (value.SideEffects != null)
                    existingTypes.SideEffects = value.SideEffects;
                if (value.High != null)
                    existingTypes.High = value.High;
                if (value.IncreaseApetite != null)
                    existingTypes.IncreaseApetite = value.IncreaseApetite;
                if (value.PainReliever != null)
                    existingTypes.PainReliever = value.PainReliever;
                if (value.ReduceAnxiety != null)
                    existingTypes.ReduceAnxiety = value.ReduceAnxiety;
                if (value.EaseMigraine != null)
                    existingTypes.EaseMigraine = value.EaseMigraine;

                _context.SaveChanges();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var type = _context.Types
               .Where(s => s.Id == id)
               .FirstOrDefault();

            _context.Remove(type);
            _context.SaveChanges();
        }
    }
}
