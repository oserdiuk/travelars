using System.Web.Http;
using AutoMapper;
using Swashbuckle.Swagger.Annotations;
using Travelars.DTO;
using Travelars.Models;
using Travelars.Services.Abstract;

namespace Travelars.ApiControllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("")]
        [SwaggerOperation]
        [HttpPost]
        public IHttpActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userModel = _mapper.Map<UserModel>(model);
            var id = _userService.CreateUser(userModel);
            return Ok(id);
        }

        [Route("")]
        [SwaggerOperation]
        [HttpPut]
        public IHttpActionResult ResetPassword(string password)
        {
           return Ok();
        }
    }
}
