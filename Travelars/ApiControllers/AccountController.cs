using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Travelars.DTO.Account;
using Travelars.Models;
using Travelars.Services.Abstract.AccountServices;

namespace Travelars.ApiControllers
{
    [RoutePrefix("api/")]
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(
            IAccountService accountService,
            IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var registrationModel = _mapper.Map<RegistrationModel>(model);
                _accountService.Register(registrationModel);
                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("login")]
        [HttpPost]
        public HttpResponseMessage Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var token = _accountService.Login(model.Email, model.Password);
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("logout")]
        [HttpPost]
        public HttpResponseMessage Logout([FromBody] string userToken)
        {
            if (ModelState.IsValid)
            {
                _accountService.Logout(userToken);
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
