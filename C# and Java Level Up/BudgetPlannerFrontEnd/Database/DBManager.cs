using BudgetPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlannerFrontEnd.Database
{
    public class DBManager : DbContext
    {

        public DBManager(DbContextOptions<DBManager> options) : base(options)
        {
        }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
