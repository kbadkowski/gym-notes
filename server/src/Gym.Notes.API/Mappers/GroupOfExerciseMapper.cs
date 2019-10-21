using Gym.Notes.API.WebModels;
using Gym.Notes.Infrastructure.Models;

namespace Gym.Notes.API.Mappers
{
    public static class GroupOfExerciseMapper
    {
        public static GroupOfExerciseWebModel ToWebModel(this GroupsOfExercisesModel model)
        {
            return new GroupOfExerciseWebModel
            {
                Id = model.Id,
                DayOfWeek = model.DayOfWeek,
                GroupOfExercise = model.GroupOfExercise
            };
        }
    }
}
