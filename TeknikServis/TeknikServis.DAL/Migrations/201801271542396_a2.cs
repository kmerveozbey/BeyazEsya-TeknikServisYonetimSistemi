namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Teknisyenler", "Meslek");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teknisyenler", "Meslek", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
