using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerHub.Database
{
  public class DBManager : DbContext
  {
    public DBManager(DbContextOptions<DBManager> options) : base(options)
    {
    }

    public DbSet<Alcohol> alcohol { get; set; }
    public DbSet<Cocktails> cocktails { get; set; }
  }
}
