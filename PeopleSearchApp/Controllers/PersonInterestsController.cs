using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Contexts;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInterestsController : ControllerBase
    {
        private readonly PersonDbContext _context;

        public PersonInterestsController(PersonDbContext context)
        {
            _context = context;
        }

        // GET: api/PersonInterests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonInterest>>> GetPersonInterest()
        {
            return await _context.PersonInterest.ToListAsync();
        }

        // GET: api/PersonInterests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonInterest>> GetPersonInterest(int id)
        {
            var personInterest = await _context.PersonInterest.FindAsync(id);

            if (personInterest == null)
            {
                return NotFound();
            }

            return personInterest;
        }

        // PUT: api/PersonInterests/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonInterest(int id, PersonInterest personInterest)
        {
            personInterest.Id = id;

            _context.Entry(personInterest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonInterestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonInterests
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PersonInterest>> PostPersonInterest(PersonInterest personInterest)
        {
            _context.PersonInterest.Add(personInterest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonInterest", new { id = personInterest.Id }, personInterest);
        }

        // DELETE: api/PersonInterests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonInterest>> DeletePersonInterest(int id)
        {
            var personInterest = await _context.PersonInterest.FindAsync(id);
            if (personInterest == null)
            {
                return NotFound();
            }

            _context.PersonInterest.Remove(personInterest);
            await _context.SaveChangesAsync();

            return personInterest;
        }

        private bool PersonInterestExists(int id)
        {
            return _context.PersonInterest.Any(e => e.Id == id);
        }
    }
}
