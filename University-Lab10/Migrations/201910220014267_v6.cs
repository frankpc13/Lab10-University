namespace University_Lab10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.People", name: "isActive", newName: "isActive1");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.People", name: "isActive1", newName: "isActive");
        }
    }
}
