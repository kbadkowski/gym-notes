using System;

namespace Gym.Notes.Infrastructure.Models
{
    public class GroupsOfExercisesModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string GroupOfExercise { get; set; }
    }
}
