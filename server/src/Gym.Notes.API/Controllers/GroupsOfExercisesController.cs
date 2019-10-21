using Gym.Notes.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Gym.Notes.API.Mappers;
using Gym.Notes.API.WebModels;
using Gym.Notes.Infrastructure.Models;
using System;

namespace Gym.Notes.API.Controllers
{
    [Authorize]
    [Route("api/groupsOfExercises")]
    public class GroupsOfExercisesController : Controller
    {
        private readonly Infrastructure.DbContext _databaseContext;

        public GroupsOfExercisesController(Infrastructure.DbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserGroupsOfExercises()
        {
            var userId = User.GetId();

            var userGroupsOfExercises = await _databaseContext.GroupsOfExercises
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return await Task.FromResult(
                Ok(userGroupsOfExercises.Select(x => x.ToWebModel())));
        }

        [HttpPost]
        public async Task<IActionResult> AddUserGroupOfExercise(
            [FromBody] GroupOfExerciseWebModel webModel)
        {
            var groupOfExercise = new GroupsOfExercisesModel
            {
                UserId = User.GetId(),
                DayOfWeek = webModel.DayOfWeek,
                GroupOfExercise = webModel.GroupOfExercise
            };

            await _databaseContext.GroupsOfExercises.AddAsync(groupOfExercise);
            await _databaseContext.SaveChangesAsync();

            return await Task.FromResult(Created(string.Empty, groupOfExercise));
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> EditUserGroupOfExercise(
            [FromBody] GroupOfExerciseWebModel webModel, Guid id)
        {
            var entity = await _databaseContext.GroupsOfExercises
                .FirstOrDefaultAsync(x => x.Id == id);

            entity.DayOfWeek = webModel.DayOfWeek;
            entity.GroupOfExercise = webModel.GroupOfExercise;

            _databaseContext.GroupsOfExercises.Update(entity);
            await _databaseContext.SaveChangesAsync();

            return await Task.FromResult(Ok());
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteUserGroupOfExercise(Guid id)
        {
            var entity = await _databaseContext.GroupsOfExercises
                .FirstOrDefaultAsync(x => x.Id == id);

            _databaseContext.GroupsOfExercises.Remove(entity);
            await _databaseContext.SaveChangesAsync();

            return await Task.FromResult(Ok());
        }
    }
}