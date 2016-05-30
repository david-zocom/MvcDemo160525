using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAjaxDemo.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MvcAjaxDemo.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public async Task<ActionResult> Index()
        {
            ZooContext context1 = new ZooContext();
            ZooContext context2 = new ZooContext();
            ZooContext context3 = new ZooContext();

            context3.Djur.Add(new Djur() { Art = "panda", AntalBen = 4 });
            context3.Djur.Add(new Djur() { Art = "giraff", AntalBen = 4 });

            Task<int> saveTask = context3.SaveChangesAsync();
            Task<int> countTask = context1.Djur.CountAsync();
            Task<int> sumTask = context2.Djur.SumAsync(d => d.AntalBen);

            int x = await saveTask;
            // context3 är färdig med SaveChanges
            int count = await countTask;
            int sum = await sumTask;
            ViewBag.count = count;
            ViewBag.sum = sum;
            return View();
        }

        public ActionResult Api()
        {
            ZooContext context = new ZooContext();
            int count = context.Djur.Count();
            return Json(new { Count = count },
                JsonRequestBehavior.AllowGet);
        }
    }
}