namespace WorkoutWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Password = c.String(),
                        PasswordSalt = c.String(),
                        Locked = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        LastLogon = c.DateTime(),
                        FailedLogonTries = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
