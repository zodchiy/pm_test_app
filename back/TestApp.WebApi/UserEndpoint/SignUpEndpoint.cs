using Ardalis.ApiEndpoints;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestApp.Core;
using TestApp.Core.Entities;
using TestApp.Core.Interfaces;
using TestApp.Infrastructure.Identity;

namespace TestApp.WebApi.UserEndpoint
{
    public class SignUpEndpoint : EndpointBaseAsync
    .WithRequest<SignUpRequest>
    .WithActionResult<SignUpResponse>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenClaimsService _tokenClaimsService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<User> _userRepository;
        public SignUpEndpoint(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
        ITokenClaimsService tokenClaimsService, IRepository<User> userRepository)
        {
            _signInManager = signInManager;
            _tokenClaimsService = tokenClaimsService;
            _userManager = userManager;
            _userRepository = userRepository;
        }
        [HttpPost("api/signup")]
        [SwaggerOperation(
           Summary = "Sign up a user",
           Description = "Sign ups a user",
           Tags = new[] { "SignUpEndpoints" })]
        public override async Task<ActionResult<SignUpResponse>> HandleAsync(SignUpRequest request,
       CancellationToken cancellationToken = default)
        {
            var response = new SignUpResponse(request.CorrelationToken());
            var newUser = new ApplicationUser { UserName = request.Login, Email = request.Login };
            var identityRes = await _userManager.CreateAsync(newUser, request.Password);
            if(identityRes.Succeeded)
            {
                var newIdentityUser = await _userManager.FindByEmailAsync(request.Login);
                if(newIdentityUser != null)
                {
                    var newuser = new User(newIdentityUser.Id.ToString(), request.CountryId, request.ProvinceId);
                    _ = await _userRepository.AddAsync(newuser);
                }
                
            }
            else
            {
                response.Error = string.Join(';', identityRes.Errors.Select(x => x.Description));
            }
            response.Result = identityRes.Succeeded;
            //if login
            /*if(identityRes.Succeeded)
            {
                var result = await _signInManager.PasswordSignInAsync(request.Login, request.Password, false, true);
                response.Result = result.Succeeded;
            }    */

            return response;
        }
    }
}
