using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAPI.Helpers
{
    public static class Helper
    {
        public static string ResetPasswordEmailMessage(string callbackUrl)
        {
            string message = "<b>Good Day!</b><br/><br/><p>You have requested to change your password. <br/><br/> Please reset your password by clicking this </p><br/><a href=\"" + callbackUrl + "\">link</a><br/><br/><b>Thank you.</b>";
            return message;
        }
    }
}