namespace Amazon.Server.Features.Identity.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginResponseModel
    {
        public string Token { get; set; }

        public string UserId { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
