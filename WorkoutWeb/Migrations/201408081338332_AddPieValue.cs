namespace WorkoutWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPieValue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PieValues",
                c => new
                    {
                        PieValueId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.Int(),
                        UserName = c.String(),
                        DataDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PieValueId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PieValues");
        }
    }
}
