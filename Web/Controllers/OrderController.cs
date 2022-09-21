using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete.EF;
using Entities.Concrete;
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

        [Route("order-ekle")]
        [HttpPost]
        public IActionResult Add(Order order)
        {
            order.ID = Guid.NewGuid();
            order.kCount = order.k28+order.k30+order.k32+order.k34+order.k36+order.k38+order.k40+order.k42+order.k44+order.k46+order.k48+order.k50;
            order.sCount = order.s28+order.s30+order.s32+order.s34+order.s36+order.s38+order.s40+order.s42+order.s44+order.s46+order.s48+order.s50;

            if (ModelState.IsValid)
            {
                om.Add(order);
                return RedirectToAction("index","order");
            }
            else{
                return View(order);
            }
          
        }

        [Route("order-detay")]
        public IActionResult Details(Guid id)
        {
            return View(om.Get(id));
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}