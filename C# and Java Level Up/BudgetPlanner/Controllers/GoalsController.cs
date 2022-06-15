using BudgetPlanner.Database;
using BudgetPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.Controllers
{
  [Route("api/Goals")]
  [ApiController]
  public class GoalsController : ControllerBase
  {
    private readonly DBManager _context;

    public GoalsController(DBManager context)
    {
      _context = context;
    }
    // GET: api/Transactions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transactions>>> GetGoals()
    {
      return await _context.Transactions.ToListAsync();
    }

    // goals/params?token=1&&categoryID=3&&month=11
    [HttpGet("params")]
    public async Task<List<Goals>> GetTransactionsByUserCategory(int token, int categoryID, int month)
    {
      string months = month.ToString();
      if(months.Length == 1)
      {
        months = "0" + months;
      }
      var transactions = await _context.Transactions.Where(x => x.Token == token && x.CategoryID == categoryID && x.TransactionDate.Substring(5, 2).Equals(month)).ToListAsync();

      decimal sumTrans = 0;

      foreach (Transactions tran in transactions)
      {
        sumTrans = sumTrans + tran.TransactionAmount;

      }

      List<Goals> x = new List<Goals>();
      

      if (_context.Categories.Find(categoryID).CategoryGoal < sumTrans)
        x.Add(new Goals {GoalAmount = _context.Categories.Find(categoryID).CategoryGoal,  GoalMet = false, AmountSpent = sumTrans  });
      else
        x.Add(new Goals { GoalAmount = _context.Categories.Find(categoryID).CategoryGoal, GoalMet = true, AmountSpent = sumTrans });

      return x;
    }

  }
}
