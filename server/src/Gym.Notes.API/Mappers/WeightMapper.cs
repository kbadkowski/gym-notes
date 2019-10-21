using Gym.Notes.API.WebModels;
using Gym.Notes.Infrastructure.Models;


namespace Gym.Notes.API.Mappers
{
    public static class WeightMapper
    {
        public static WeightWebModel ToWebModel(this WeightModel model)
        {
            return new WeightWebModel
            {
                Id = model.Id,
                Date = model.Date,
                Weight = model.Weight
            };
        }
    }
}
