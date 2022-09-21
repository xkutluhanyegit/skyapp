using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    
    public class CuttingController : Controller
    {
        private readonly ILogger<CuttingController> _logger;

        public CuttingController(ILogger<CuttingController> logger)
        {
            _logger = logger;
        }

        [Route("kesimhane")]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}