using Gym.Notes.API.WebModels;
using Gym.Notes.Infrastructure.Models;

namespace Gym.Notes.API.Mappers
{
    public static class TaskMapper
    {
        public static TaskWebModel ToWebModel(this TaskModel model)
        {
            return new TaskWebModel
            {
                Id = model.Id,
                Date = model.Date,
                Title = model.Title,
                Content = model.Content,
                Done = model.Done
            };
        }
    }
}
