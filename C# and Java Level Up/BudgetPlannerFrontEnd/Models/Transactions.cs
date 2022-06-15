using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlanner.Models
{
  public class Transactions
  {
    [Key]
    public int TransactionID { get; set; }

    public decimal TransactionAmount { get; set; }

    [ForeignKey("Accounts")]
    public int AccountID { get; set; }

    [ForeignKey("Category")]
    public int CategoryID { get; set; }

    [ForeignKey("Users")]
    public int Token { get; set; }

    public string TransactionDate { get; set; }
  }
}
