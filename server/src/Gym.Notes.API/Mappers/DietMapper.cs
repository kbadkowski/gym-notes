using Gym.Notes.API.WebModels;
using Gym.Notes.Infrastructure.Models;

namespace Gym.Notes.API.Mappers
{
    public static class DietMapper
    {
        public static DietWebModel ToWebModel(this DietModel model)
        {
            return new DietWebModel
            {
                Id = model.Id,
                Date = model.Date,
                Kcals = model.Kcals
            };
        }
    }
}
