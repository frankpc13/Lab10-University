namespace University_Lab10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "isActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.People", "isActive1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "isActive1", c => c.Boolean());
            AlterColumn("dbo.People", "isActive", c => c.Boolean());
        }
    }
}
