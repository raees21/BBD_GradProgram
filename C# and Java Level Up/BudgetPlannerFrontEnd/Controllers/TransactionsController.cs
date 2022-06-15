using BudgetPlanner.Models;
using BudgetPlannerFrontEnd.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BudgetPlannerFrontEnd.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly DBManager _db;

        public TransactionsController(DBManager db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Transactions> transactions = _db.Transactions.Where(x => x.Token == Globals.userID).OrderByDescending(x => x.TransactionDate).ToList();

            if (transactions == null)
            {
                return NotFound();
            }

            return View(transactions);
        }

        public IActionResult Add()
        {
            return View();
        }

    }
}
