using AccountBalance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AccountBalance.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        private readonly IAccountRepository _repo;
        public LoginController(IAccountRepository repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        [Route("api/Login")]
        [HttpPost]
        public HttpResponseMessage Login(string username, string password)
        {
            var user = _repo.OnGetUser(username, password);
            if (user == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "User Not Found");

            return Request.CreateResponse(HttpStatusCode.OK, user.Roles);
        }
    }
}
