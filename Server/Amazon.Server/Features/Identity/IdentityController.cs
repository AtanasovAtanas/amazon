namespace Amazon.Server.Features.Identity
{
    using System.Threading.Tasks;

    using Amazon.Server.Data.Models;
    using Amazon.Server.Features.Identity.Models;
    using Amazon.Server.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identity;
        private readonly AppSettings appSettings;

        public IdentityController(
            UserManager<User> userManager,
            IIdentityService identity,
            IOptions<AppSettings> appSettings)
        {
            this.userManager = userManager;
            this.identity = identity;
            this.appSettings = appSettings.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Register))]
        public async Task<ActionResult<LoginResponseModel>> Register(RegisterRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.Email,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return this.BadRequest(result.Errors);
            }

            var loginRequestModel = new LoginRequestModel
            {
                Password = model.Password,
                Email = model.Email,
            };

            return await this.Login(loginRequestModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                return this.Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return this.Unauthorized();
            }

            var token = this.identity.GenerateJwtToken(
                user.Id,
                user.UserName,
                this.appSettings.Secret);

            return new LoginResponseModel
            {
                UserId = user.Id,
                Email = user.Email,
                Token = token,
            };
        }

        [HttpGet]
        [Authorize]
        public ActionResult<LoginResponseModel> GetUserDetails()
        {
            var userId = this.User.GetId();
            var username = this.User.Identity.Name;

            return new LoginResponseModel
            {
                UserId = userId,
                Email = username,
                Token = this.identity.GenerateJwtToken(userId, username, this.appSettings.Secret),
            };
        }
    }
}
