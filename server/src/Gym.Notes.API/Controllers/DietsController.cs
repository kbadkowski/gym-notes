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
    [Route("api/diets")]
    public class DietsController : Controller
    {
        private readonly Infrastructure.DbContext _databaseContext;

        public DietsController(Infrastructure.DbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDiets()
        {
            var userId = User.GetId();

            var userDiets = await _databaseContext.Diets
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return await Task.FromResult(
                Ok(userDiets.Select(x => x.ToWebModel())));
        }

        [HttpPost]
        public async Task<IActionResult> AddUserDiet(
            [FromBody] DietWebModel webModel)
        {
            var diet = new DietModel
            {
                UserId = User.GetId(),
                Date = webModel.Date,
                Kcals = webModel.Kcals
            };

            await _databaseContext.Diets.AddAsync(diet);
            await _databaseContext.SaveChangesAsync();

            return await Task.FromResult(Created(string.Empty, diet));
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> EditUserDiet(
            [FromBody] DietWebModel webModel, Guid id)
        {
            var entity = await _databaseContext.Diets
                .FirstOrDefaultAsync(x => x.Id == id);

            entity.Date = webModel.Date;
            entity.Kcals = webModel.Kcals;

            _databaseContext.Diets.Update(entity);
            await _databaseContext.SaveChangesAsync();

            return await Task.FromResult(Ok());
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteUserDiet(Guid id)
        {
            var entity = await _databaseContext.Diets
                .FirstOrDefaultAsync(x => x.Id == id);

            _databaseContext.Diets.Remove(entity);
            await _databaseContext.SaveChangesAsync();

            return await Task.FromResult(Ok());
        }
    }
}