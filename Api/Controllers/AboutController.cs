using Api.Models;
using Api.Services.About;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _service;
        public AboutController(IAboutService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetModel());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(AboutViewModel model)
        {
            _service.SetModel(model);

            return RedirectToAction("Index");
        }
    }
}
