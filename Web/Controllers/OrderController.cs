using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        
        OrderManager om = new OrderManager(new EfOrderDal());

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [Route("siparis-detay")]
        public IActionResult Index()
        {
            return View(om.GetAll());
        }

        [Route("order-ekle")]
        [HttpGet]
        public IActionResult Add()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}