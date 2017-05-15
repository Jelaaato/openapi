using Microsoft.AspNet.Identity;
using OpenAPI.Models.OpenAPIIdentity;
using OpenAPI.Models.OpenAPIIdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using Microsoft.AspNet.Identity.Owin;
using OpenAPI.Methods;
using OpenAPI.Helpers;

namespace OpenAPI.Controllers
{
    public class AccountController : ApiController
    {
        [Route("registeruser")]
        public IHttpActionResult RegisterUser(RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users { UserName = model.firstCredential, Email = model.email};
                IdentityResult result = UserManager.Create(user, model.password);
                if (result.Succeeded)
                {
                    var userId = API.GetUserId(model.firstCredential);
                    var role = API.GetRole(model.userType);
                    try
                    {
                        UserManager.AddToRole(userId, role);
                        return Ok();
                    }
                    catch (Exception e)
                    {
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("An error has occured : {0}", e.Message)));
                    }
                }
                else
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Conflict, String.Format("Error : User was not created.")));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("forgotpassword")]
        public IHttpActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = UserManager.FindByEmail(model.email);

                    if (user == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        string code = UserManager.GeneratePasswordResetToken(user.Id);
                        code = HttpUtility.UrlEncode(code);
                        var callbackUrl = Url.Route("resetpassword", new { userId = user.Id, code = code });
                        UserManager.SendEmail(user.Id, "ResetPassword", Helper.ResetPasswordEmailMessage(callbackUrl));
                        return Ok(code);
                    }
                }
                catch (Exception e)
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("An error has occured : {0}", e.Message)));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }  
        }

        [Route("resetpassword", Name="resetpassword")]
        public IHttpActionResult ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = UserManager.FindByName(model.username);

                    if (user == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        var result = UserManager.ResetPassword(user.Id, HttpUtility.UrlDecode(model.code), model.password);
                        if (result.Succeeded)
                        {
                            return Ok();
                        }
                        else
                        {
                            return Conflict();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("An error has occured : {0}", e.Message)));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private UsersManager UserManager
        {
            get { return HttpContext.Current.GetOwinContext().GetUserManager<UsersManager>(); }
        }
    }
}
