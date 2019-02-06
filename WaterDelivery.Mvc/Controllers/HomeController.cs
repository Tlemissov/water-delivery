using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterDelivery.Core.Common;
using WaterDelivery.Core.Orders;
using WaterDelivery.EntityFrameworkCore.Data;
using WaterDelivery.Mvc.Models;

namespace WaterDelivery.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Order(OrderDto input)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    FullName = input.FullName,
                    Adress = input.Adress,
                    Phone = input.Phone,
                    Quantity = input.Quantity,
                    OrderDate = DateTime.Now,
                    Status = OrderStatus.New
                };
                db.Orders.Add(order);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(input);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
