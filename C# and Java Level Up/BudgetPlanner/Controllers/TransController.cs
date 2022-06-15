using BudgetPlanner.Database;
using BudgetPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BudgetPlanner.Controllers
{
    public class TransController : Controller
    {
        private readonly DBManager _db;

        public TransController(DBManager db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Transactions> transactions = _db.Transactions.Where(x => x.Token == 2).ToList();


            if (transactions == null)
            {
                return NotFound();
            }

            return View(transactions);
        }
        // GET: api/Transactions/[token] : api/Transactions/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetTransactionsByUser(int token)
        {
            IEnumerable<Transactions> transactions = _db.Transactions.Where(x => x.Token == token).ToList();


            if (transactions == null)
            {
                return NotFound();
            }

            return View(transactions);
        }
    }
}
