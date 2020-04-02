﻿using System;
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
    public class PersonAddressesController : ControllerBase
    {
        private readonly PersonDbContext _context;

        public PersonAddressesController(PersonDbContext context)
        {
            _context = context;
        }

        // GET: api/PersonAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonAddress>>> GetPersonAddress()
        {
            return await _context.PersonAddress.ToListAsync();
        }

        // GET: api/PersonAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonAddress>> GetPersonAddress(int id)
        {
            var personAddress = await _context.PersonAddress.FindAsync(id);

            if (personAddress == null)
            {
                return NotFound();
            }

            return personAddress;
        }

        // PUT: api/PersonAddresses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonAddress(int id, PersonAddress personAddress)
        {
            personAddress.Id = id;

            _context.Entry(personAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonAddressExists(id))
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

        // POST: api/PersonAddresses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PersonAddress>> PostPersonAddress(PersonAddress personAddress)
        {
            _context.PersonAddress.Add(personAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonAddress", new { id = personAddress.Id }, personAddress);
        }

        // DELETE: api/PersonAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonAddress>> DeletePersonAddress(int id)
        {
            var personAddress = await _context.PersonAddress.FindAsync(id);
            if (personAddress == null)
            {
                return NotFound();
            }

            _context.PersonAddress.Remove(personAddress);
            await _context.SaveChangesAsync();

            return personAddress;
        }

        private bool PersonAddressExists(int id)
        {
            return _context.PersonAddress.Any(e => e.Id == id);
        }
    }
}
