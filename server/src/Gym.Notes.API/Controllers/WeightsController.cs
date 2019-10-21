using Gym.Notes.API.Extensions;
using Gym.Notes.API.Mappers;
using Gym.Notes.API.WebModels;
using Gym.Notes.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Notes.API.Controllers
{
    [Authorize]
    [Route("api/weights")]
    public class WeightsController : Controller
    {
        private readonly Infrastructure.DbContext _databaseContext;

        public WeightsController(Infrastructure.DbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserWeights()
        {
            var userId = User.GetId();

            var userWeights = await _databaseContext.Weights
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return await Task.FromResult(
                Ok(userWeights.Select(x => x.ToWebModel())));
        }

        [HttpPost]
        public async Task<IActionResult> AddUserWeight(
            [FromBody] WeightWebModel webModel)
        {
            var weight = new WeightModel
            {
                UserId = User.GetId(),
                Date = webModel.Date,
                Weight = webModel.Weight
            };

            await _databaseContext.Weights.AddAsync(weight);
            await _databaseContext.SaveChangesAsync();

            return await Task.FromResult(Created(string.Empty, weight));
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> EditUserWeight(
            [FromBody] WeightWebModel webModel, Guid id)
        {
            var entity = await _databaseContext.Weights
                .FirstOrDefaultAsync(x => x.Id == id);

            entity.Date = webModel.Date;
            entity.Weight = webModel.Weight;

            _databaseContext.Weights.Update(entity);
            await _databaseContext.SaveChangesAsync();

            return await Task.FromResult(Ok());
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteUserWeight(Guid id)
        {
            var entity = await _databaseContext.Weights
                .FirstOrDefaultAsync(x => x.Id == id);

            _databaseContext.Weights.Remove(entity);
            await _databaseContext.SaveChangesAsync();

            return await Task.FromResult(Ok());
        }
    }
}