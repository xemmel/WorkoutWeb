using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorkoutWeb.Models
{
  public class WWDataContext : DbContext
  {
    public WWDataContext() : base("name=WWConnection")
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<PieValue> PieValues { get; set; }
    public DbSet<Category> Categories { get; set; }
  }
}