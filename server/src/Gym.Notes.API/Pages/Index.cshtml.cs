using Gym.Notes.API.Areas.Identity.Pages.Account;
using Gym.Notes.Infrastructure;
using Gym.Notes.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Notes.API.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DbContext _dbContext;
        private readonly ILogger<LoginModel> _logger;

        public IndexModel(
            DbContext dbContext,
            ILogger<LoginModel> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var subscriberFound = _dbContext.Subscribers.Any(x => x.Email == Input.Email);

                if(subscriberFound == true)
                {
                    ModelState.AddModelError(string.Empty, "Already added to subscribers");
                }

                var subscriber = new SubscriberModel
                {
                    Email = Input.Email
                };

                await _dbContext.Subscribers.AddAsync(subscriber);
                await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Subscriber added successfully");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid email");
            }
        }
    }
}