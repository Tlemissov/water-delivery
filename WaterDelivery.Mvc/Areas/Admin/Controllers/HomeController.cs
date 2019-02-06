using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaterDelivery.Core.Common;
using WaterDelivery.EntityFrameworkCore.Data;

namespace WaterDelivery.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Orders.Where(x => x.IsDeleted == false).OrderByDescending(x => x.OrderDate).ToListAsync());
        }

        public async Task<IActionResult> Accept(int id)
        {
            var order = await db.Orders.FindAsync(id);
            order.Status = OrderStatus.Checked;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Send(int id)
        {
            var order = await db.Orders.FindAsync(id);
            order.Status = OrderStatus.Shipped;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delivered(int id)
        {
            var order = await db.Orders.FindAsync(id);
            order.Status = OrderStatus.Delivered;
            order.DeliveryDate = DateTime.Now;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = await db.Orders.FindAsync(id);
            if(order.Status == OrderStatus.Delivered)
            {
                order.IsDeleted = true;
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}