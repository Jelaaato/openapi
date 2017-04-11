namespace OpenAPI.Migrations
{
    using Microsoft.AspNet.Identity;
    using OpenAPI.Helpers;
    using OpenAPI.Models.OpenAPIIdentity;
    using OpenAPI.Models.RefreshTokenModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OpenAPI.Models.OpenAPIIdentity.OpenAPIAuthenticationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OpenAPI.Models.OpenAPIIdentity.OpenAPIAuthenticationContext context)
        {
            var hashPassword = new PasswordHasher();
            string pass = hashPassword.HashPassword("@Pp$d3v");
            context.Users.AddOrUpdate(u => u.UserName, new Users
            {
                UserName = "@dministrator",
                PasswordHash = pass
            });

            if (context.OpenAPIClients.Count() > 0)
            {
                return;
            }

            context.OpenAPIClients.AddRange(CreateClientList());
            context.SaveChanges();
        }

        private static List<OpenAPIClient> CreateClientList()
        {
            List<OpenAPIClient> ClientList = new List<OpenAPIClient>
            {
                new OpenAPIClient
                {
                    Id = "COA01",
                    Secret = Hasher.GetHash("open@pi01"),
                    Name = "ClientConfidential",
                    AppType = ApplicationTypes.AppTypes.NativeConfidential,
                    Active_Flag = true,
                    RefreshToken_LifeSpan = 1440,
                    Allowed_Origin = "*"
                },

                new OpenAPIClient
                {
                    Id = "COA02",
                    Secret = Hasher.GetHash("open@pi02"),
                    Name = "ClientConfidential",
                    AppType = ApplicationTypes.AppTypes.NativeConfidential,
                    Active_Flag = true,
                    RefreshToken_LifeSpan = 1440,
                    Allowed_Origin = "*"
                },

                new OpenAPIClient
                {
                    Id = "COA03",
                    Secret = Hasher.GetHash("open@pi03"),
                    Name = "ClientConfidential",
                    AppType = ApplicationTypes.AppTypes.NativeConfidential,
                    Active_Flag = true,
                    RefreshToken_LifeSpan = 1440,
                    Allowed_Origin = "*"
                },

                new OpenAPIClient
                {
                    Id = "COA04",
                    Secret = Hasher.GetHash("open@pi04"),
                    Name = "ClientConfidential",
                    AppType = ApplicationTypes.AppTypes.NativeConfidential,
                    Active_Flag = true,
                    RefreshToken_LifeSpan = 1440,
                    Allowed_Origin = "*"
                },

                new OpenAPIClient
                {
                    Id = "COA05",
                    Secret = Hasher.GetHash("open@pi05"),
                    Name = "ClientConfidential",
                    AppType = ApplicationTypes.AppTypes.NativeConfidential,
                    Active_Flag = true,
                    RefreshToken_LifeSpan = 1440,
                    Allowed_Origin = "*"
                },

                new OpenAPIClient
                {
                    Id = "COA06",
                    Secret = Hasher.GetHash("open@pi06"),
                    Name = "ClientConfidential",
                    AppType = ApplicationTypes.AppTypes.NativeConfidential,
                    Active_Flag = true,
                    RefreshToken_LifeSpan = 1440,
                    Allowed_Origin = "*"
                },

                new OpenAPIClient
                {
                    Id = "COA07",
                    Secret = Hasher.GetHash("open@pi07"),
                    Name = "ClientConfidential",
                    AppType = ApplicationTypes.AppTypes.NativeConfidential,
                    Active_Flag = true,
                    RefreshToken_LifeSpan = 1440,
                    Allowed_Origin = "*"
                },

                new OpenAPIClient
                {
                    Id = "COA08",
                    Secret = Hasher.GetHash("open@pi08"),
                    Name = "ClientConfidential",
                    AppType = ApplicationTypes.AppTypes.NativeConfidential,
                    Active_Flag = true,
                    RefreshToken_LifeSpan = 1440,
                    Allowed_Origin = "*"
                },

                new OpenAPIClient
                {
                    Id = "COA09",
                    Secret = Hasher.GetHash("open@pi09"),
                    Name = "ClientConfidential",
                    AppType = ApplicationTypes.AppTypes.NativeConfidential,
                    Active_Flag = true,
                    RefreshToken_LifeSpan = 1440,
                    Allowed_Origin = "*"
                },

                new OpenAPIClient
                {
                    Id = "COA010",
                    Secret = Hasher.GetHash("open@pi10"),
                    Name = "ClientConfidential",
                    AppType = ApplicationTypes.AppTypes.NativeConfidential,
                    Active_Flag = true,
                    RefreshToken_LifeSpan = 1440,
                    Allowed_Origin = "*"
                },

                new OpenAPIClient
                {
                    Id = "COA0Test",
                    Secret = Hasher.GetHash("open@pitest"),
                    Name = "ClientConfidential",
                    AppType = ApplicationTypes.AppTypes.NativeConfidential,
                    Active_Flag = true,
                    RefreshToken_LifeSpan = 1440,
                    Allowed_Origin = "*"
                }
            };
            return ClientList;
        }
    }
}
