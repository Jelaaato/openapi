using OpenAPI.Models.OpenAPIIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAPI.Methods
{
    public class API
    {
        private static OpenAPIAuthenticationContext db = new OpenAPIAuthenticationContext();

        public static string GetUserId(string userName)
        {
            var userId = db.Users.Where(u => u.UserName == userName).Select(u => u.Id).First();

            return userId;
        }

        public static string GetRole(int userType)
        {
            switch (userType)
            {
                case 1:
                    return "Patient";
                case 2:
                    return "Doctor";
                case 3:
                    return "Employee";
                default:
                    return "Invalid Role";
            }
        }
    }
}