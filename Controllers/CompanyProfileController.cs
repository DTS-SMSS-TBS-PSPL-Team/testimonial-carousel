using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TS.Data;
using TS.Models;
using TS.Services;

namespace TS.Controllers
{
    public class CompanyProfileController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<RegisteredUser> _manager;
        private readonly SignInManager<RegisteredUser> _signInManager;
        private readonly IWebHostEnvironment _iweb;
        private readonly IOptions<SMSSSmtpClientSettings> _options;

        public CompanyProfileController(ApplicationDbContext context, UserManager<RegisteredUser> manager,
                                          SignInManager<RegisteredUser> signInManager, IWebHostEnvironment iweb, IOptions<SMSSSmtpClientSettings> options)
        {
            _context = context;
            _manager = manager;
            _signInManager = signInManager;
            _iweb = iweb;
            _options = options;
        }

    }
}
