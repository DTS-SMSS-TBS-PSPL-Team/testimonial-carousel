// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TS.Data;
using TS.Models;

namespace TS.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<RegisteredUser> _signInManager;
        private readonly UserManager<RegisteredUser> _userManager;
        private readonly IUserStore<RegisteredUser> _userStore;
        private readonly IUserEmailStore<RegisteredUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public RegisterModel(
            UserManager<RegisteredUser> userManager,
            //IUserStore<RegisteredUser> userStore,
            SignInManager<RegisteredUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context
            )
        {
            _userManager = userManager;
           // _userStore = userStore;
            //_emailStore = GetEmailStore();
            _signInManager = signInManager;
            _emailSender = emailSender;
            _context = context;
            _logger = logger;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Required]
            [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Use letters only")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} Length must be between {2} and {1} character.")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} Length must be between {2} and {1} character.")]
            [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Use letters only")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(13, MinimumLength = 10)]
            [DataType(DataType.PhoneNumber, ErrorMessage = "Provided phone number not valid")]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]

            [Display(Name = "Phone Number")]
            public string UserPhone { get; set; }

            [Display(Name = "User Type Name")]
            public string UserTypeName { get; set; }

            public byte UserFlag { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            string role = "";
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new RegisteredUser();

                //await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                //await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                //var result = await _userManager.CreateAsync(user, Input.Password);

                if (Input.UserTypeName == null)
                {
                    user.UserName = Input.Email;
                    user.Email = Input.Email;
                    user.FirstName = Input.FirstName;
                    user.LastName = Input.LastName;
                    user.UserPhone = Input.UserPhone;
                    user.UserFlag = 2;
                    role = "User";
                }
                else
                {
                    user.UserName = Input.Email;
                    user.Email = Input.Email;
                    user.FirstName = Input.FirstName;
                    user.LastName = Input.LastName;
                    user.UserPhone = Input.UserPhone;
                    user.UserTypeName = Input.UserTypeName;
                    user.UserFlag = 3;
                    role = "Admin";
                }

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    var isAdded = await _userManager.AddToRoleAsync(user, role);
                    if (isAdded.Succeeded)
                    {
                        int userId = user.Id;
                        if (Input.UserTypeName == null)
                        {
                            ApplicantProfile applicantProfile = new ApplicantProfile() { RegisteredUserId = userId, JobProfession = "" };
                            _context.ApplicantProfiles.Add(applicantProfile);
                            _context.SaveChanges();
                        }
                        else
                        {
                            AdminProfile adminProfile = new AdminProfile() { RegisteredUserId = userId, ContactName = Input.FirstName + " " + Input.LastName, ContactPhone = Input.UserPhone };
                            _context.AdminProfiles.Add(adminProfile);
                            _context.SaveChanges();
                        }
                    }

                    //var userId = await _userManager.GetUserIdAsync(user);




                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    if (user.UserTypeName == null) 
                    {
                        await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                            $"<h1>Welcome to TS!</h1><br>Hello " + Input.FirstName + ",<br><br> Thank you for getting started with TS! " +
                            $"We need a little more information to complete your registration, including confirmation of your account. <br>" +
                            $"Please Click on this link to confirm your account: <a href='{HtmlEncoder.Default.Encode(callbackUrl)}' class='theme-btn btn-sm'>Click Here</a>" +
                            $"<br><br><b>New User Register</b><br> Username: " + Input.Email + "<br> Password: " + Input.Password +
                            $"<br><br>If you are facing any trouble to login, please contact our team by filling out the form available at <a asp-controller='Home'" +
                            $"<br><br> You are receiving this because you’ve signed up for a new account.");
                    } else
                    {
                        await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                            $"<h1>Welcome to TS!</h1><br>Hello " + Input.UserTypeName + ",<br><br> Thank you for getting started with TS! " +
                            $"We need a little more information to complete your registration, including confirmation of your account. <br>" +
                            $"Please Click on this link to confirm your account: <a href='{HtmlEncoder.Default.Encode(callbackUrl)}' class='theme-btn btn-sm'>Click Here</a>" +
                            $"<br><br><b>New User Register</b><br> Username: " + Input.Email + "<br> Password: " + Input.Password +
                            $"<br><br> After Email Confirmation we need 2 days to review Admin profile for Approval Kindly fill the Admin profile to complete the aproval process" +
                            $"<br><br> " +
                            $"<br><br> You are receiving this because you’ve signed up for a new account.");

                        await _emailSender.SendEmailAsync("donotreply@ts.com", "Admin Approval Request",
                       $"Hello Admin,<br> " + Input.FirstName + " has successfully created an account on our website. " +
                       $"Kindly verify the details of the registered employer from the admin dashboard. <br>" +
                       $"<br><b>New User Register</b><br> Email: " + Input.Email +
                       $"<br> User Type Name: " + Input.UserTypeName +
                       $"<br> Phone Number: " + Input.UserPhone +
                       $"<br><br> Thanks, <br> TS Support ");
                    }

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        //private IdentityUser CreateUser()
        //{
        //    try
        //    {
        //        return Activator.CreateInstance<IdentityUser>();
        //    }
        //    catch
        //    {
        //        throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
        //            $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
        //            $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        //    }
        //}

        //private IUserEmailStore<IdentityUser> GetEmailStore()
        //{
        //    if (!_userManager.SupportsUserEmail)
        //    {
        //        throw new NotSupportedException("The default UI requires a user store with email support.");
        //    }
        //    return (IUserEmailStore<IdentityUser>)_userStore;
        //}
    }
}
