namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anketler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UyeId = c.String(maxLength: 128),
                        SoruTuruId = c.Int(nullable: false),
                        ToplamPuan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SoruTurleri", t => t.SoruTuruId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UyeId)
                .Index(t => t.UyeId)
                .Index(t => t.SoruTuruId);
            
            CreateTable(
                "dbo.SoruTurleri",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Turu = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AnketSorulari",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoruTuruId = c.Int(nullable: false),
                        Soru = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SoruTurleri", t => t.SoruTuruId, cascadeDelete: true)
                .Index(t => t.SoruTuruId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Ad = c.String(maxLength: 25),
                        Soyad = c.String(maxLength: 25),
                        KayitTarihi = c.DateTime(nullable: false),
                        AktivasyonKodu = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.ArizaKayitlari",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UyeId = c.String(maxLength: 128),
                        TeknisyenID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teknisyenler", t => t.TeknisyenID)
                .ForeignKey("dbo.AspNetUsers", t => t.UyeId)
                .Index(t => t.UyeId)
                .Index(t => t.TeknisyenID);
            
            CreateTable(
                "dbo.ArizaDetaylari",
                c => new
                    {
                        ArizaID = c.Int(nullable: false),
                        Konum = c.String(nullable: false),
                        Mesaj = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ArizaID)
                .ForeignKey("dbo.ArizaKayitlari", t => t.ArizaID)
                .Index(t => t.ArizaID);
            
            CreateTable(
                "dbo.Dosyalar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DosyaYolu = c.String(),
                        Uzanti = c.String(),
                        ArizaDetayID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ArizaDetaylari", t => t.ArizaDetayID)
                .Index(t => t.ArizaDetayID);
            
            CreateTable(
                "dbo.ArizaDurumDetaylari",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ArizaKayitID = c.Int(nullable: false),
                        YapilanIslemler = c.String(nullable: false),
                        GarantiTipi = c.Byte(nullable: false),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IslemBittiMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ArizaKayitlari", t => t.ArizaKayitID, cascadeDelete: true)
                .Index(t => t.ArizaKayitID);
            
            CreateTable(
                "dbo.Teknisyenler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UyeId = c.String(maxLength: 128),
                        Meslek = c.String(nullable: false, maxLength: 100),
                        BostaMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UyeId)
                .Index(t => t.UyeId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Mesajlar",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MessageDate = c.DateTime(nullable: false),
                        Content = c.String(nullable: false),
                        SendBy = c.String(nullable: false, maxLength: 128),
                        SentTo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SendBy, cascadeDelete: true)
                .Index(t => t.SendBy);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Aciklama = c.String(maxLength: 200),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Mesajlar", "SendBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ArizaKayitlari", "UyeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Teknisyenler", "UyeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ArizaKayitlari", "TeknisyenID", "dbo.Teknisyenler");
            DropForeignKey("dbo.ArizaDurumDetaylari", "ArizaKayitID", "dbo.ArizaKayitlari");
            DropForeignKey("dbo.Dosyalar", "ArizaDetayID", "dbo.ArizaDetaylari");
            DropForeignKey("dbo.ArizaDetaylari", "ArizaID", "dbo.ArizaKayitlari");
            DropForeignKey("dbo.Anketler", "UyeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Anketler", "SoruTuruId", "dbo.SoruTurleri");
            DropForeignKey("dbo.AnketSorulari", "SoruTuruId", "dbo.SoruTurleri");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Mesajlar", new[] { "SendBy" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Teknisyenler", new[] { "UyeId" });
            DropIndex("dbo.ArizaDurumDetaylari", new[] { "ArizaKayitID" });
            DropIndex("dbo.Dosyalar", new[] { "ArizaDetayID" });
            DropIndex("dbo.ArizaDetaylari", new[] { "ArizaID" });
            DropIndex("dbo.ArizaKayitlari", new[] { "TeknisyenID" });
            DropIndex("dbo.ArizaKayitlari", new[] { "UyeId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AnketSorulari", new[] { "SoruTuruId" });
            DropIndex("dbo.Anketler", new[] { "SoruTuruId" });
            DropIndex("dbo.Anketler", new[] { "UyeId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Mesajlar");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Teknisyenler");
            DropTable("dbo.ArizaDurumDetaylari");
            DropTable("dbo.Dosyalar");
            DropTable("dbo.ArizaDetaylari");
            DropTable("dbo.ArizaKayitlari");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AnketSorulari");
            DropTable("dbo.SoruTurleri");
            DropTable("dbo.Anketler");
        }
    }
}
