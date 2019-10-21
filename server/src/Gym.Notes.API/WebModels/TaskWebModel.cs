using System;

namespace Gym.Notes.API.WebModels
{
    public class TaskWebModel
    {
        public Guid? Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Done { get; set; }
    }
}
