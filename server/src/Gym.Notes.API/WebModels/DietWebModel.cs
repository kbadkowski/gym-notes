using System;

namespace Gym.Notes.API.WebModels
{
    public class DietWebModel
    {
        public Guid? Id { get; set; }
        public DateTime Date { get; set; }
        public double Kcals { get; set; }
    }
}
