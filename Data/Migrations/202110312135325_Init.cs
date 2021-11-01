namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Address", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.User", "Mobile", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Mobile");
            DropColumn("dbo.User", "Address");
        }
    }
}
