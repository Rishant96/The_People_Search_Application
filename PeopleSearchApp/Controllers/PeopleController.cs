using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PeopleSearchApp.Contexts;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PersonDbContext _context;

        public PeopleController(PersonDbContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetPeople()
        {
            var people_dto = await _context.People
                        .Include(p => p.Address)
                        .Include(p => p.Interests)
                        .Select(p => PersonToDTO(p))
                        .ToListAsync();

            for (int i=0; i < people_dto.Count; i++)
            {
                people_dto[i].Age = DateTime.Now.Year - people_dto[i].DOB.Year;
                if (DateTime.Now.DayOfYear < people_dto[i].DOB.DayOfYear)
                {
                    people_dto[i].Age -= 1;
                }
            }

            return people_dto;
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTO>> GetPerson(int id)
        {
            var person_m = await _context.People
                .Include(p => p.Address)
                .Include(p => p.Interests)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person_m == null)
            {
                return NotFound();
            }

            var person = PersonToDTO(person_m);
            person.Age = DateTime.Now.Year - person.DOB.Year;
            if (DateTime.Now.DayOfYear < person.DOB.DayOfYear)
            {
                person.Age -= 1;
            } 

            return person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, PersonDTO personDTO)
        {
            if (id != personDTO.Id)
            {
                return BadRequest();
            }

            var person = await _context.People
                .Include(p => p.Address)
                .Include(p => p.Interests)
                .FirstOrDefaultAsync(p => p.Id == id);

            person.FirstName = personDTO.FirstName;
            person.MiddleName = personDTO.MiddleName;
            person.LastName = personDTO.LastName;
            person.Address = personDTO.Address;
            person.PersonAddressId = personDTO.PersonAddressId;
            person.DOB = new DateTime(personDTO.DOB.Year, personDTO.DOB.Month, personDTO.DOB.Day);
            person.PathToAvatar = personDTO.PathToAvatar;

            _context.Entry(person).State = EntityState.Modified;
            if (personDTO.Address != null)
            {
                _context.Entry(personDTO.Address).State = EntityState.Modified;
            }
            if (personDTO.Interests != null)
            {
                foreach (var interest in personDTO.Interests) 
                {
                    _context.Entry(interest).State = EntityState.Modified;
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var person = await _context.People
                .Include(p => p.Address)
                .Include(p => p.Interests)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            if (person.Address != null)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete,
                        Request.Scheme
                        + "://"
                        + Request.Host.Value
                        + Request.PathBase.Value
                        + "/api/PersonAddresses/"
                        + person.Address.Id);
                    requestMessage.Content = new StringContent(
                            "", Encoding.UTF8, "application/json"
                        );
                    HttpResponseMessage response = client.SendAsync(requestMessage).GetAwaiter().GetResult();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            try
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return person;
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }

        private static PersonDTO PersonToDTO(Person person) =>
            new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                LastName = person.LastName,
                Address = person.Address,
                PersonAddressId = person.PersonAddressId,
                PathToAvatar = person.PathToAvatar,
                Age = 0,
                DOB = person.DOB.Date,
                Interests = person.Interests
            };
    }
}
