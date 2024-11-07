using DateTimeApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DateTimeApp.Controllers
{
    // Ensure the API route is defined
    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeController : ControllerBase
    {
        // In-memory store for DateTime records
        private static List<DateTimeRecord> _records = new List<DateTimeRecord>
        {
            new DateTimeRecord { Id = 1, Date = DateTime.Now, Description = "Initial Record" }
        };

        // GET: api/DateTime
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_records);
        }

        // GET: api/DateTime/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var record = _records.FirstOrDefault(r => r.Id == id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        // POST: api/DateTime
        [HttpPost]
        public IActionResult Create([FromBody] DateTimeRecord record)
        {
            if (record == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            record.Id = _records.Max(r => r.Id) + 1;
            _records.Add(record);
            return CreatedAtAction(nameof(Get), new { id = record.Id }, record);
        }

        // PUT: api/DateTime/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DateTimeRecord record)
        {
            if (id != record.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingRecord = _records.FirstOrDefault(r => r.Id == id);
            if (existingRecord == null)
            {
                return NotFound();
            }

            existingRecord.Date = record.Date;
            existingRecord.Description = record.Description;
            return NoContent();
        }

        // DELETE: api/DateTime/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var record = _records.FirstOrDefault(r => r.Id == id);
            if (record == null)
            {
                return NotFound();
            }
            _records.Remove(record);
            return NoContent();
        }
    }
}
