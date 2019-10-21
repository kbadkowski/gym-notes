using System;

namespace Gym.Notes.API.WebModels
{
    public class GroupOfExerciseWebModel
    {
        public Guid? Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string GroupOfExercise { get; set; }
    }
}
