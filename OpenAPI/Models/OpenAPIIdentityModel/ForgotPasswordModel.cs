using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenAPI.Models.OpenAPIIdentityModel
{
    public class ForgotPasswordModel
    {
        [Required]
        public string email { get; set; }
    }
}