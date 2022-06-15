using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlanner.Models
{
  public class Accounts
  {
    [Key]
    public int AccountID { get; set; }

    public string AccountType { get; set; }

    public string AccountName { get; set; }

    [ForeignKey("Users")]
    public int Token { get; set; }
    }
}
