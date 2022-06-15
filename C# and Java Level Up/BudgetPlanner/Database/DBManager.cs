using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlanner.Database
{
  public class DBManager : DbContext
  {

    public DBManager(
    DbContextOptions<DBManager> options)
    : base(options)
    {
    }

    public DbSet<Models.Accounts> Accounts { get; set; }
    public DbSet<Models.Categories> Categories { get; set; }
    public DbSet<Models.Transactions> Transactions { get; set; }
    public DbSet<Models.Users> Users { get; set; }

  }
}
