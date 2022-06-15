using BudgetPlanner.Models;
using BudgetPlannerFrontEnd.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BudgetPlannerFrontEnd.Controllers
{
    public class GoalsController : Controller
    {
        private readonly DBManager _db;

        public GoalsController(DBManager db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            decimal limit = (decimal)_db.Categories.Where(x => x.CategoryID == Globals.categoryID).First().CategoryGoal;
            decimal sum = (decimal)_db.Transactions.Where(x => x.Token == Globals.userID && x.CategoryID == Globals.categoryID).Sum(t => t.TransactionAmount);
            string met;
            if (limit < sum)
            {
                met = "Overspent";
            }
            else
            {
                met = "Goal not met";
            }

            Goals goals = new Goals();
            goals.GoalMet = met;
            goals.GoalAmount = limit;
            goals.AmountSpent = sum;
            return View(goals);
        }
    }
}
