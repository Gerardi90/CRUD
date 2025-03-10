﻿namespace CRUD.API.Entities
{
    public class Event
    {

        public Event() 
        {   
            Speakers = new List<EventSpeakers>();
            IsDeleted = false;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; } 

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 

        public List<EventSpeakers> Speakers { get; set; }

        public bool IsDeleted { get; set; }

        public void Update(string title, string description, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

    }
}
