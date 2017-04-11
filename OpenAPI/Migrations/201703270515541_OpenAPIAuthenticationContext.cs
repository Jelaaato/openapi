namespace OpenAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpenAPIAuthenticationContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpenAPIClients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Secret = c.String(),
                        Name = c.String(nullable: false, maxLength: 250),
                        AppType = c.Int(nullable: false),
                        Active_Flag = c.Boolean(nullable: false),
                        RefreshToken_LifeSpan = c.Int(nullable: false),
                        Allowed_Origin = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpenAPIRefreshTokens",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Subject = c.String(nullable: false, maxLength: 250),
                        ClientId = c.String(nullable: false, maxLength: 100),
                        IssuedUTC = c.DateTime(nullable: false),
                        ExpiresUTC = c.DateTime(nullable: false),
                        Protected_Ticket = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpenAPIRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.OpenAPIUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.OpenAPIRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.OpenAPIUsers", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.OpenAPIUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpenAPIUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OpenAPIUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.OpenAPIUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.OpenAPIUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OpenAPIUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.OpenAPIUsers");
            DropForeignKey("dbo.OpenAPIUserRoles", "IdentityUser_Id", "dbo.OpenAPIUsers");
            DropForeignKey("dbo.OpenAPIUserLogin", "IdentityUser_Id", "dbo.OpenAPIUsers");
            DropForeignKey("dbo.OpenAPIUserClaims", "IdentityUser_Id", "dbo.OpenAPIUsers");
            DropForeignKey("dbo.OpenAPIUserRoles", "RoleId", "dbo.OpenAPIRoles");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.OpenAPIUserLogin", new[] { "IdentityUser_Id" });
            DropIndex("dbo.OpenAPIUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.OpenAPIUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.OpenAPIUserRoles", new[] { "RoleId" });
            DropIndex("dbo.OpenAPIRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.OpenAPIUserLogin");
            DropTable("dbo.OpenAPIUserClaims");
            DropTable("dbo.OpenAPIUsers");
            DropTable("dbo.OpenAPIUserRoles");
            DropTable("dbo.OpenAPIRoles");
            DropTable("dbo.OpenAPIRefreshTokens");
            DropTable("dbo.OpenAPIClients");
        }
    }
}
