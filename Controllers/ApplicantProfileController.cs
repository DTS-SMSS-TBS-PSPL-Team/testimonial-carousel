using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.WebPages;
using TS.Data;
using TS.Models;
using TS.Services;
using TS.ViewModels;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace TS.Controllers
{
    //[Authorize(AuthenticationSchemes="Indentity.Application", Roles="User")]
    public class ApplicantProfileController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<RegisteredUser> _manager;
        private readonly SignInManager<RegisteredUser> _signInManager;
        private readonly IWebHostEnvironment _iweb;
        private readonly IOptions<SMSSSmtpClientSettings> _options;


        [Obsolete]
        public ApplicantProfileController(ApplicationDbContext context, UserManager<RegisteredUser> manager,
                                          SignInManager<RegisteredUser> signInManager, IWebHostEnvironment iweb, IOptions<SMSSSmtpClientSettings> options)
        {
            _context = context;
            _manager = manager;
            _signInManager = signInManager;
            _iweb = iweb;
            _options = options;
        }


        public IActionResult GetDashboardTest()
        {
            ApplicantProfile profile = GetApplicantInfo();
            ViewData["UserFullName"] = profile.RegisteredUser.FirstName + " " + profile.RegisteredUser.LastName;
            ViewBag.ProfilePicture = profile.ProfileImg;

            int id = int.Parse(_manager.GetUserId(HttpContext.User));
            IQueryable<JobsDateGroup> data = from jobs in _context.ApplicantJobApplications
                                             .Where(ja => ja.ApplicantProfileId == id)
                                             group jobs by jobs.ApplicationDate.Date
                                             into dateGroup
                                             select new JobsDateGroup()
                                             {
                                                 applicationDate = dateGroup.Key,
                                                 jobCount = dateGroup.Count()
                                             };
            return View(data);
        }

        public IActionResult GetDashboard()
        {
            ApplicantProfile profile = GetApplicantInfo();
            ViewData["UserFullName"] = profile.RegisteredUser.FirstName + " " + profile.RegisteredUser.LastName;
            ViewBag.ProfilePicture = profile.ProfileImg;

            int id = int.Parse(_manager.GetUserId(HttpContext.User));
            int applicantId = _context.ApplicantProfiles.FirstOrDefault(ap => ap.RegisteredUserId == id).Id;
            IQueryable<JobsDateGroup> data = from jobs in _context.ApplicantJobApplications
                                             .Where(ja => ja.ApplicantProfileId == applicantId)
                                             group jobs by jobs.ApplicationDate.Date
                                             into dateGroup
                                             select new JobsDateGroup()
                                             {
                                                 applicationDate = dateGroup.Key,
                                                 jobCount = dateGroup.Count()
                                             };
            return View(data);
            
        }
        [HttpGet]
        public IActionResult AdminDashboard()
        {
            return View();
        }

        private ApplicantProfile GetApplicantInfo()
        {
            int id = int.Parse(_manager.GetUserId(HttpContext.User));
            
            ApplicantProfile profile = _context.ApplicantProfiles
                .Include(ap => ap.RegisteredUser)
                .AsNoTracking()
                .FirstOrDefault(u => u.RegisteredUserId == id);
            //if(profile == null){
            //    return id
            //}
            return profile;
        }
        [HttpGet]
        public IActionResult GetAllTestimonials()
        {
        var testimonialList = _context.ApplicantTestimonials.ToList();
            List<AdminProfile> newTestimonials = new List<AdminProfile>();
            foreach(var item in testimonialList)
            {
                AdminProfile list = new AdminProfile();
               var allist=list.ApplicantTestimonial=item;
                allist.Testimonial=item.Testimonial;
                allist.Description=item.Description;
                allist.IsApprove=item.IsApprove;
                newTestimonials.Add(list);
            }
            return View(newTestimonials);
        }
        [HttpGet]
        //public IActionResult AddTestimonial()
        //{int id=int.Parse(_manager.GetUserId(HttpContext.User));
        //    ApplicantTestimonial applicantTestimonial = _context.ApplicantTestimonials.Where(a => a.ApplicantProfileId == id).FirstOrDefault();
        //    //ApplicantTestimonial applicantTestimonial = _context.ApplicantTestimonials.Where(a=>a.).ToList();
        //    return View();
        //}
        [HttpGet]
        public IActionResult Details(int id)
        {
            var applicantTestimonial = _context.ApplicantTestimonials.Find(id);
            if (applicantTestimonial == null)
            {
                return NotFound();
            }
            return View(applicantTestimonial);
        }
        // [HttpPost]
        //public async Task<IActionResult> AddTestimonial(string Testimonial, string Description)
        //{
        //    int id = int.Parse(_manager.GetUserId(HttpContext.User));
        //    ApplicantProfile profile = GetApplicantInfo();
        //    if(!Testimonial.IsEmpty() && !Description.IsEmpty())
        //    { 
        //    ApplicantTestimonial applicantTestimonial = new ApplicantTestimonial();
        //    applicantTestimonial.ApplicantProfileId = profile.Id;
        //    applicantTestimonial.Testimonial=Testimonial.ToString();
        //    applicantTestimonial.Description=Description.ToString();
        //    _context.ApplicantTestimonials.Add(applicantTestimonial);
        //    await _context.SaveChangesAsync();
        //    }

        //    return RedirectToAction("AddTestimonial", "ApplicantProfile");
        //}

        //[HttpGet]
        //public IActionResult GetProfile()
        //{
        //    ViewBag.companyname = _options.Value.AppName;
        //    int id=int.Parse(_manager.GetUserId(HttpContext.User));

        //    RegisteredUser registeredUser=_context.RegisteredUsers.Include(cp=>cp.CompanyProfile).Where(cp=>cp.Id==id).FirstOrDefault();
        //    ViewData["OrganizationName"] = registeredUser.OrganizationName;
        //    ViewData["UserFullName"] = registeredUser.FirstName + "" + registeredUser.LastName;
        //    return View();
        //}

        public IActionResult GetCompanyDashboard()
        {
            ViewBag.companyName = _options.Value.AppName;

            int id = int.Parse(_manager.GetUserId(HttpContext.User));

            RegisteredUser currUser = _context.RegisteredUsers
               .Include(ru => ru.CompanyProfile)
               .Where(ru => ru.Id == id)
              .FirstOrDefault();

            ViewData["OrganizationName"] = currUser.OrganizationName;
            ViewData["UserFullName"] = currUser.FirstName + " " + currUser.LastName;
            ViewBag.Picture = currUser.CompanyProfile.CompanyLogo;

            //int companyId = _context.CompanyProfiles.FirstOrDefault(cp => cp.RegisteredUserId == id).Id;
            //IQueryable<CompanyJobPostVM> data = from jobs in _context.CompanyJobs
            //                                 .Where(ja => ja.CompanyProfileId == companyId)
            //                                    group jobs by jobs.PostingDate.Date
            //                                 into dateGroup
            //                                    select new CompanyJobPostVM()
            //                                    {
            //                                        jobPostDate = dateGroup.Key,
            //                                        jobCount = dateGroup.Count()
            //                                    };
            return View();

        }

        [HttpGet]
        public IActionResult GetProfile()
        {
            int id = int.Parse(_manager.GetUserId(HttpContext.User));
            ApplicantProfile profile = _context.ApplicantProfiles
              //.Include(u => u.ApplicantEducations)
              //.Include(u => u.ApplicantWorkHistorys)
              //.Include(u => u.ApplicantSkills)
              .Include(u => u.Country)
              //.Include(u => u.Province)
              //.Include(u => u.City)
              .FirstOrDefault(u => u.RegisteredUserId == id);
            RegisteredUser user = _context.RegisteredUsers.Include(u => u.UserSectors).FirstOrDefault(u => u.Id == id);
            ViewBag.ProfilePicture = profile.ProfileImg;
            ApplicantProfileVM profileVM = new ApplicantProfileVM()
            {
                RegisteredUser = user,
                ApplicantProfile = profile
            };

            ViewData["UserFullName"] = profileVM.RegisteredUser.FirstName + " " + profileVM.RegisteredUser.LastName;
            return View(profileVM);
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
            [HttpPost]
        public IActionResult Delete(int id)
        {
            var applicantTestimonial=_context.ApplicantTestimonials.Find(id);
            if(applicantTestimonial == null)
            {
                return NotFound();
            }
            _context.ApplicantTestimonials.Remove(applicantTestimonial);
            //_context.SaveChanges();
            return RedirectToAction("GetAllTestimonials","ApplicantProfile");
        }
        [HttpPost]
        public IActionResult GetApproval( int id, string isapprove)
        {if (isapprove!=null && isapprove == "False")
            {
                var applicantTestimonial = _context.ApplicantTestimonials.Find(id);
                // isapprove = "True";
                applicantTestimonial.IsApprove = true;
                _context.ApplicantTestimonials.Update(applicantTestimonial);
                _context.SaveChanges();
                ViewBag.SuccessMessage = " Testimonial has been approved successfully!";
            }
            return RedirectToAction("GetAllTestimonials", "ApplicantProfile");
        }

        [HttpGet]
        public IActionResult ApprovedTestimonials()
        {
            var testimonialList = _context.ApplicantTestimonials.ToList();
            List<AdminProfile> newTestimonials = new List<AdminProfile>();
            foreach (var item in testimonialList)
            {
                AdminProfile list = new AdminProfile();
                var allist = list.ApplicantTestimonial = item;
                allist.Testimonial = item.Testimonial;
                allist.Description = item.Description;
                allist.IsApprove = item.IsApprove;
                newTestimonials.Add(list);
            }
            return View(newTestimonials);
        }

       // [HttpGet]
        public IActionResult TestimonialCarousel()
        
        {
            var imgList = _context.CarouselSliderImages.OrderByDescending(cs=>cs.Id).ToList();
            List<AdminProfile> imgs = new List<AdminProfile>();
            foreach (var item in imgList)
            {
                AdminProfile list = new AdminProfile();
                var allist = list.CarouselSlider = item;
                allist.Heading_Content = item.Heading_Content;
                allist.Content_Caption = item.Content_Caption;
                allist.Carousel_Button_URL = item.Carousel_Button_URL;
                allist.CSImage = item.CSImage;
                imgs.Add(list);
            }
            return View(imgs);
        }

    }
}
