using CRUD.API.Entities;
using CRUD.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly EventsDbContex _context;

        public EventController(EventsDbContex context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        { 
             var Events = _context.Events.Where(d => !d.IsDeleted).ToList();
             
             return Ok(Events);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Event = _context.Events.SingleOrDefault(d => d.Id == id);   

            if (Event == null) 
            {
                return NotFound();
            }

            return Ok(Event);   

        }

        [HttpPost]

        public IActionResult Post(Event devEvent)
        {
            _context.Events.Add(devEvent);

            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }


        // api/events/guid PUT
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Event input)
        {
            var Event = _context.Events.SingleOrDefault(d => d.Id == id);

            if (Event == null)
            {
                return NotFound();
            }

            Event.Update(input.Title, input.Description, input.StartDate, input.EndDate);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var Event = _context.Events.SingleOrDefault(d => d.Id == id);

            if (Event == null)
            {
                return NotFound();
            }

            Event.Delete();
            return NoContent();

        }

        [HttpPost("{id}/speakers")]
        public IActionResult PostSpeaker(Guid id, EventSpeakers speaker)
        {
            var Event = _context.Events.SingleOrDefault(d => d.Id == id);

            if (Event == null) 
            {
                return NotFound();
            }

            Event.Speakers.Add(speaker);

            return NoContent();
        }

    }
}
