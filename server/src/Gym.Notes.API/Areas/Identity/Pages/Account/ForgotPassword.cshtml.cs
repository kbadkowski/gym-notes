using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace Gym.Notes.API.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly string _errorMessageUserNotExists = "User not exists";

        public ForgotPasswordModel(UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);

                if (user == null || !await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, _errorMessageUserNotExists);

                    return Page();
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(
                    Input.Email,
                    "Reset Password",
                    EmailTemplate(HtmlEncoder.Default.Encode(callbackUrl))
                    );

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }

        private string EmailTemplate(string encodedLink)
        {
            return $@"<div style='font-amily: inherit; text-align: center'>Gym Notes Service For Reseting Password</div>
                    <img style='margin-left: auto;
                        margin-right: auto;
                        padding-top: 15px;
                        padding-bottom: 15px;
                        display: block;'
                        src='https://images.unsplash.com/photo-1547919307-1ecb10702e6f?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=634&q=80'
                        alt='gym-image'
                        data-responsive='true' 
                        color: #000000;
                        text-decoration: none;
                        >
                    <div style='text-align: center'>To reset your password <a href='{encodedLink}'>click here</a></div>";
        }
    }
}
