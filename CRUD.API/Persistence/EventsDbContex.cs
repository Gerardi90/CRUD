using CRUD.API.Entities;

namespace CRUD.API.Persistence
{
    public class EventsDbContex
    {
        public List<Event> Events { get; set; }

        public EventsDbContex() 
        {
            Events = new List<Event>();
        }
    }
}
