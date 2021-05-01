namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToDosDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yapilacaks", "SonTarih", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Yapilacaks", "SonTarih");
        }
    }
}
