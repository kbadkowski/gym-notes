using System;

namespace Gym.Notes.Infrastructure.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Done { get; set; }
    }
}
