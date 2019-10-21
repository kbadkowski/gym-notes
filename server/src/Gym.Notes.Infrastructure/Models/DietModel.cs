using System;

namespace Gym.Notes.Infrastructure.Models
{
    public class DietModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public double Kcals { get; set; }
    }
}
