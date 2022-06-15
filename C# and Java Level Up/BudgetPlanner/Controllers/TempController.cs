using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.Controllers
{
    public class TempController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //// wasn't sure where to create functions. doing it here temporarily
        //// most functions here will be duplicated and edited for each model/table

        //private readonly AppDBContext _db; // needs db context to be created first

        //public TempController(AppDBContext db)
        //{
        //    _db = db;
        //}

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Add(Temp obj) // needs models to be created first
        //{
        //    // may need to check for dupicates
        //    if (ModelState.IsValid)
        //    {
        //        _db.Temps.Add(obj); // adds to categories table
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(obj);
        //}

        ////GET
        //// finds temp by id
        //public IActionResult FindTemp(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var tempFromDb = _db.Temps.Find(id);

        //    if (tempFromDb == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tempFromDb);
        //}

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(int? id)
        //{
        //    var obj = _db.Temps.Find(id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Temps.Remove(obj);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");

        //}
    }
}
