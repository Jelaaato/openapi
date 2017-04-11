using Microsoft.AspNet.Identity.EntityFramework;
using OpenAPI.Models.RefreshTokenModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OpenAPI.Models.OpenAPIIdentity
{
    public class OpenAPIAuthenticationContext : IdentityDbContext<Users>
    {
        public OpenAPIAuthenticationContext()
            : base("OpenAPIAuthenticationContext")
        { 
            
        }

        public DbSet<OpenAPIClient> OpenAPIClients { get; set; }
        public DbSet<OpenAPIRefreshToken> OpenAPIRefreshTokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("OpenAPIUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("OpenAPIRoles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("OpenAPIUserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("OpenAPIUserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("OpenAPIUserLogin");
        }

        static OpenAPIAuthenticationContext()
        {
            Database.SetInitializer<OpenAPIAuthenticationContext>(new OpenAPIAuthenticationContextDbSeed());
        }

        public static OpenAPIAuthenticationContext Create()
        {
            return new OpenAPIAuthenticationContext();
        }
    }

    public class OpenAPIAuthenticationContextDbSeed : DropCreateDatabaseIfModelChanges<OpenAPIAuthenticationContext>
    {
        protected override void Seed(OpenAPIAuthenticationContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        public void PerformInitialSetup(OpenAPIAuthenticationContext Context)
        {
            //UsersManager UserManager = new UsersManager(new UserStore<Users>(Context));
            //RolesManager RoleManager = new RolesManager(new RoleStore<roles>(Context));

            //string Name = "Administrator";
            //string UserName = "appAdmin";
            //string Password = "P0rt4l@dm!n";
            //string email = "elabetoria@asianhospital.com";


        }
    }
}