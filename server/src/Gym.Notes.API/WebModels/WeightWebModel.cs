using System;

namespace Gym.Notes.API.WebModels
{
    public class WeightWebModel
    {
        public Guid? Id { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
    }
}
