namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToDos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Yapilacaks",
                c => new
                    {
                        YapilacakId = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 100, unicode: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.YapilacakId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Yapilacaks");
        }
    }
}
