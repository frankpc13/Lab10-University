namespace University_Lab10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "isActive", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "isActive");
        }
    }
}
