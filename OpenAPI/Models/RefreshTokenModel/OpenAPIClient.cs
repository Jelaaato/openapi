using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenAPI.Models.RefreshTokenModel
{
    public class OpenAPIClient
    {
        [Key]
        public string Id { get; set; }
        public string Secret { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public ApplicationTypes.AppTypes AppType { get; set; }
        public Boolean Active_Flag { get; set; }
        public int RefreshToken_LifeSpan { get; set; }
        public string Allowed_Origin { get; set; }
    }
}