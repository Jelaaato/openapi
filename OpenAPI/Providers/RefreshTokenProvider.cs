using Microsoft.Owin.Security.Infrastructure;
using OpenAPI.Helpers;
using OpenAPI.Models.RefreshTokenModel;
using OpenAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OpenAPI.Providers
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["client_id"];

            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }

            var refreshTokenId = Guid.NewGuid().ToString("n");

            using (AuthenticationRepository _repo = new AuthenticationRepository())
            {
                var refreshTokenLifeSpan = context.OwinContext.Get<string>("clientRefreshTokenLifeSpan");

                var token = new OpenAPIRefreshToken()
                {
                    Id = Hasher.GetHash(refreshTokenId),
                    ClientId = clientid,
                    Subject = context.Ticket.Identity.Name,
                    IssuedUTC = DateTime.UtcNow,
                    ExpiresUTC = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeSpan))
                };

                context.Ticket.Properties.IssuedUtc = token.IssuedUTC;
                context.Ticket.Properties.ExpiresUtc = token.ExpiresUTC;

                token.Protected_Ticket = context.SerializeTicket();

                var result = await _repo.AddRefreshToken(token);

                if (result)
                {
                    context.SetToken(refreshTokenId);
                }
            }
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {

            var allowedOrigin = context.OwinContext.Get<string>("clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            string hashedTokenId = Hasher.GetHash(context.Token);

            using (AuthenticationRepository _repo = new AuthenticationRepository())
            {
                var refreshToken = await _repo.FindRefreshToken(hashedTokenId);

                if (refreshToken != null)
                {
                    context.DeserializeTicket(refreshToken.Protected_Ticket);
                    var result = await _repo.RemoveRefreshToken(hashedTokenId);
                }
            }
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}