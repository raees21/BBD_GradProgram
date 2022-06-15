using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlanner.Models
{
  public class Users
  {
    public string UserName { get; set; }
    [Key]
    public int Token { get; set; }

    //public int UserId { get; set; }
    }
}
