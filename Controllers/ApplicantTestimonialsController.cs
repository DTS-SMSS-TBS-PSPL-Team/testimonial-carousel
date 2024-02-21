using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TS.Controllers
{
    public class ApplicantTestimonialsController : Controller
    {
        // GET: ApplicantTestimonialsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ApplicantTestimonialsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicantTestimonialsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicantTestimonialsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicantTestimonialsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicantTestimonialsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicantTestimonialsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicantTestimonialsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
