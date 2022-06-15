using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlanner.Models
{
  public class Categories
  {
    [Key]
    public int CategoryID { get; set; }

    public string CategoryName { get; set; }

    public decimal CategoryGoal { get; set; }

  }
}
