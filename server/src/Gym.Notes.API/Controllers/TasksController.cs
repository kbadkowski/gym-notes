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
    [Route("api/tasks")]
    public class TasksController : Controller
    {
        private readonly Infrastructure.DbContext _databaseContext;

        public TasksController(Infrastructure.DbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserTasks()
        {
            var userId = User.GetId();

            var userTasks = await _databaseContext.Diets
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return await Task.FromResult(
                Ok(userTasks.Select(x => x.ToWebModel())));
        }

        [HttpPost]
        public async Task<IActionResult> AddUserTask(
            [FromBody] TaskWebModel webModel)
        {
            var task = new TaskModel
            {
                UserId = User.GetId(),
                Date = webModel.Date,
                Title = webModel.Title,
                Content = webModel.Content,
                Done = webModel.Done
            };

            await _databaseContext.Tasks.AddAsync(task);
            await _databaseContext.SaveChangesAsync();

            return await Task.FromResult(Created(string.Empty, task));
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> EditUserTask(
            [FromBody] TaskWebModel webModel)
        {
            var entity = await _databaseContext.Tasks
                .FirstOrDefaultAsync(x => x.Id == webModel.Id);

            entity.Date = webModel.Date;
            entity.Title = webModel.Title;
            entity.Content = webModel.Content;
            entity.Done = webModel.Done;

            _databaseContext.Tasks.Update(entity);
            await _databaseContext.SaveChangesAsync();

            return await Task.FromResult(Ok());
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteUserTask(Guid id)
        {
            var entity = await _databaseContext.Tasks
                .FirstOrDefaultAsync(x => x.Id == id);

            _databaseContext.Tasks.Remove(entity);
            await _databaseContext.SaveChangesAsync();

            return await Task.FromResult(Ok());
        }
    }
}