namespace WorkoutWeb.Migrations
{
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;
  using WorkoutWeb.Models;

  internal sealed class Configuration : DbMigrationsConfiguration<WorkoutWeb.Models.WWDataContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(WorkoutWeb.Models.WWDataContext context)
    {

      var userAdmin = new User() { UserName = "lacour", FullName = "Morten la Cour", IsAdmin = true };
      userAdmin.setPassword("clara");

      var userNonAdmin = new User() { UserName = "morten", FullName = "Morten Non Admin" };
      userNonAdmin.setPassword("1234");

      context.Users.AddOrUpdate(u => u.UserName,
        userAdmin, userNonAdmin);


      context.PieValues.AddOrUpdate(p => p.Name,
          new PieValue() { Name = "Grapes", Value = 10.4m },
          new PieValue() { Name = "Orange", Value = 13 }
          );

      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data. E.g.
      //
      //    context.People.AddOrUpdate(
      //      p => p.FullName,
      //      new Person { FullName = "Andrew Peters" },
      //      new Person { FullName = "Brice Lambson" },
      //      new Person { FullName = "Rowan Miller" }
      //    );
      //
    }
  }
}
