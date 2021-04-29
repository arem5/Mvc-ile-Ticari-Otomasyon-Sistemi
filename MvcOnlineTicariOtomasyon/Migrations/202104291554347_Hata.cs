namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hata : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Personels", "PersonelMahalle");
            DropColumn("dbo.Personels", "PersonelSokak");
            DropColumn("dbo.Personels", "PersonelApartmanKapiNo");
            DropColumn("dbo.Personels", "PersonelSemtSehir");
            DropColumn("dbo.Personels", "PersonelPhone");
            DropColumn("dbo.Personels", "PersonelEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personels", "PersonelEmail", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.Personels", "PersonelPhone", c => c.String(maxLength: 11, unicode: false));
            AddColumn("dbo.Personels", "PersonelSemtSehir", c => c.String(maxLength: 40, unicode: false));
            AddColumn("dbo.Personels", "PersonelApartmanKapiNo", c => c.String(maxLength: 40, unicode: false));
            AddColumn("dbo.Personels", "PersonelSokak", c => c.String(maxLength: 40, unicode: false));
            AddColumn("dbo.Personels", "PersonelMahalle", c => c.String(maxLength: 40, unicode: false));
        }
    }
}
