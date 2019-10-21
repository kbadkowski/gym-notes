using Gym.Notes.API.Extensions;
using Gym.Notes.API.WebModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gym.Notes.API.Controllers 
{ 
    [Authorize]
    public class UserInfoController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserInfoController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet, Route("api/self")]
        public async Task<IActionResult> GetUserInfo()
        {
            var identityUser = await _userManager.GetUserAsync(User);

            var user = new UserInfoWebModel
            {
                Id = User.GetId(),
                Email = User.GetEmail(),
                PhoneNumber = await _userManager.GetPhoneNumberAsync(identityUser)
            };

            return Ok(user);
        }
    }
}