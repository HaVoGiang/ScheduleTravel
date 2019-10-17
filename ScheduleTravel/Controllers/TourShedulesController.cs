using ScheduleTravel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScheduleTravel.Controllers
{
    public class TourShedulesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: TourShedules
        
        public ActionResult Index()
        {
            var t = db.TourSchedules.OrderBy(x => new { x.SortByDay, x.TimeStart}).ToList();
            return View(t);
        }

        [HttpPost]
        public JsonResult UpdateData(TourSchedule[] data)
        {
            foreach (var item in data)
            {
                item.CreateDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Json(data);
        } 
    }
}