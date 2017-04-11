using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenAPI.Models.RefreshTokenModel
{
    public class OpenAPIRefreshToken
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(100)]
        public string ClientId { get; set; }
        public DateTime IssuedUTC { get; set; }
        public DateTime ExpiresUTC { get; set; }
        [Required]
        public string Protected_Ticket { get; set; }
    }
}