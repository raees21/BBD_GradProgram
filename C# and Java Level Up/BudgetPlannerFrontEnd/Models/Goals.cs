using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlanner.Models
{
  public class Goals
  {
    [NotMapped]
    public string GoalMet { get; set; }

    [NotMapped]
    public decimal AmountSpent { get; set; }

    [NotMapped]
    public decimal GoalAmount { get; set; }
  }
}
