using BudgetPlanner.Models;
using BudgetPlannerFrontEnd.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BudgetPlannerFrontEnd.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DBManager _db;

        public CategoriesController(DBManager db)
        {
            _db = db;
        }
        public IActionResult Index(Goals goals)
        {
            return View(goals);
        }

        public IActionResult CategoryGoals()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryGoals(string categoryName)
        {
            Console.WriteLine(categoryName);
            decimal limit = (decimal)_db.Categories.Where(x => x.CategoryName == categoryName).First().CategoryGoal;
            int categoryID = _db.Categories.Where(x => x.CategoryName == categoryName).First().CategoryID;
            decimal sum = (decimal)_db.Transactions.Where(x => x.Token == Globals.userID && x.CategoryID == categoryID).Sum(t => t.TransactionAmount);
            string met;
            if (limit < sum)
            {
                met = "Overspent";
            }
            else
            {
                met = "Goal met";
            }

            Goals goals = new Goals();
            goals.GoalMet = met;
            goals.GoalAmount = limit;
            goals.AmountSpent = sum;
            return RedirectToAction("Index", goals);
        }
    }
}
