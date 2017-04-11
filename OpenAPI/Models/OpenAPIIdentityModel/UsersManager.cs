using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAPI.Models.OpenAPIIdentity
{
    public class UsersManager : UserManager<Users>
    {
        public UsersManager(IUserStore<Users> store)
            : base(store) { }

        public static UsersManager Create(IdentityFactoryOptions<UsersManager> options, IOwinContext context)
        {
            OpenAPIAuthenticationContext db = context.Get<OpenAPIAuthenticationContext>();
            UsersManager manager = new UsersManager(new UserStore<Users>(db));

            manager.UserValidator = new UserValidator<Users>(manager) { AllowOnlyAlphanumericUserNames = false };

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<Users>(dataProtectionProvider.Create("ActivAsian-API"));
            }

            return manager;
        }
    }
}