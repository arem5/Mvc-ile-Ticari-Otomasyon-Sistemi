namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPasswordCari : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carilers", "CariSifre", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carilers", "CariSifre");
        }
    }
}
