using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using NdtLesson08Annotation.Models;

namespace NdtLesson08Annotation.Controllers
{
    public class NdtHomeController : Controller
    {
        private readonly ILogger<NdtHomeController> _logger;

        public NdtHomeController(ILogger<NdtHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NdtIndex()
        {
            return View("NdtIndex"); // yêu cầu View có tên NdtIndex.cshtml
        }

        public IActionResult NdtAbout()
        {
            return View("NdtAbout"); // yêu cầu View có tên NdtAbout.cshtml
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
