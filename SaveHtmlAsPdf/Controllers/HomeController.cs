using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using SaveHtmlAsPdf.Models;
using System.Diagnostics;

namespace SaveHtmlAsPdf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Document()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GeneratePdf()
        {
            return new ViewAsPdf("~/Views/Home/Document.cshtml") {
                FileName = $"{Path.GetRandomFileName()}.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape };
        }

        [HttpPost]
        public IActionResult GenerateFromUrl(ReportDetails obj)
        {
            return new UrlAsPdf(obj.Url) 
            { FileName = $"{Path.GetRandomFileName()}.pdf"
            , PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}