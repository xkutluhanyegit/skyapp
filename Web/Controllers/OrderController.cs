using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        
        

        private readonly IWebHostEnvironment _env;
        IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IWebHostEnvironment env,IOrderService orderService)
        {
            _logger = logger;
            _env = env;
            _orderService = orderService;
        }

        [Route("siparis-detay")]
        public IActionResult Index()
        {
            
            return View(_orderService.GetAll());
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
        public IActionResult Add(OrderVM order)
        {
            order.ID = Guid.NewGuid();
            order.kCount = order.k28+order.k30+order.k32+order.k34+order.k36+order.k38+order.k40+order.k42+order.k44+order.k46+order.k48+order.k50;
            order.sCount = order.s28+order.s30+order.s32+order.s34+order.s36+order.s38+order.s40+order.s42+order.s44+order.s46+order.s48+order.s50;

            if (ModelState.IsValid)
            {
                var dir = _env.WebRootPath+"//Images//OrderImages";
                var orderImgName = Guid.NewGuid().ToString()+".png";
                using (var fileStream = new FileStream(Path.Combine(dir,orderImgName),FileMode.Create,FileAccess.ReadWrite))
                {
                   if (order.photo!=null)
                   {
                     order.photo.CopyTo(fileStream);
                     order.PhotoPath = "/Images/OrderImages/"+orderImgName;
                   }
                   else{
                    order.PhotoPath = "/Images/OrderImages/no-img.png";
                   }
                
                }
                
                
                var res = _orderService.Add(order);
                TempData["message"] = res.Message;
                
                return RedirectToAction("index","order");
            }
            else{
                return View(order);
            }
          
        }

        
        [Route("order-detay")]
        public IActionResult Details(Guid id)
        {
            return View(_orderService.Get(id));
        }

        [Route("order-guncelleme")]
        [HttpGet]
        public IActionResult Update(Guid id)
        {
          return View(_orderService.Get(id));
        }

        [Route("order-guncelleme")]
        [HttpPost]
        public IActionResult Update(Order order,IFormFile file)
        {
            order.kCount = order.k28+order.k30+order.k32+order.k34+order.k36+order.k38+order.k40+order.k42+order.k44+order.k46+order.k48+order.k50;
            order.sCount = order.s28+order.s30+order.s32+order.s34+order.s36+order.s38+order.s40+order.s42+order.s44+order.s46+order.s48+order.s50;

            if (ModelState.IsValid)
            {
                var dir = _env.WebRootPath+"//Images//OrderImages";
                var orderImgName = Guid.NewGuid().ToString()+".png";
                using (var fileStream = new FileStream(Path.Combine(dir,orderImgName),FileMode.Create,FileAccess.ReadWrite))
                {
                    file.CopyTo(fileStream);
                
                }
                order.PhotoPath = "/Images/OrderImages/"+orderImgName;
                _orderService.Update(order);
                return RedirectToAction("index","order");
            }
            else{
                return View(order);
            }
        }

        [Route("order-sil")]
        public IActionResult Delete(Guid id)
        {
          _orderService.Delete(_orderService.Get(id));
          return RedirectToAction("index","order");
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}