using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OpenAPI.Models.OpenAPIIdentity;
using OpenAPI.Models.OpenAPIIdentityModel;
using OpenAPI.Models.RefreshTokenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OpenAPI.Repositories
{
    public class AuthenticationRepository : IDisposable
    {
        private OpenAPIAuthenticationContext ctx;

        private UserManager<IdentityUser> userManager;

        public AuthenticationRepository()
        {
            ctx = new OpenAPIAuthenticationContext();
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel client)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = client.UserName
            };

            var res = await userManager.CreateAsync(user, client.Password);
            return res;
        }

        public async Task<IdentityUser> FindUser(string UserName, string Password)
        {
            IdentityUser user = await userManager.FindAsync(UserName, Password);

            return user;
        }

        public OpenAPIClient Find_Client(string clientId)
        {
            var client = ctx.OpenAPIClients.Find(clientId);
            return client;
        }

        public async Task<bool> AddRefreshToken(OpenAPIRefreshToken token)
        {
            var exist_Token = ctx.OpenAPIRefreshTokens.Where(r => r.Subject == token.Subject & r.ClientId == token.ClientId).SingleOrDefault();
            if (exist_Token != null)
            {
                var res = await RemoveRefreshToken(exist_Token);
            }

            ctx.OpenAPIRefreshTokens.Add(token);
            return await ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await ctx.OpenAPIRefreshTokens.FindAsync(refreshTokenId);
            if (refreshToken != null)
            {
                ctx.OpenAPIRefreshTokens.Remove(refreshToken);
                return await ctx.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(OpenAPIRefreshToken refreshToken)
        {
            ctx.OpenAPIRefreshTokens.Remove(refreshToken);
            return await ctx.SaveChangesAsync() > 0;
        }

        public async Task<OpenAPIRefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await ctx.OpenAPIRefreshTokens.FindAsync(refreshTokenId);

            return refreshToken;
        }

        public List<OpenAPIRefreshToken> GetAll()
        {
            return ctx.OpenAPIRefreshTokens.ToList();
        }

        public void Dispose()
        {
            ctx.Dispose();
            userManager.Dispose();
        }
    }
}