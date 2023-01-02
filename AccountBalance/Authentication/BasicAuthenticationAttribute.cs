using AccountBalance.Context;
using AccountBalance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AccountBalance.Authentication
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private const string Realm = "My Realm";

        //private readonly IAccountRepository _repo;

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                if (actionContext.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
                }
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                string username = usernamePasswordArray[0];
                string password = usernamePasswordArray[1];
                AccountContext db = new AccountContext();
                var user = db.Users.FirstOrDefault(x => x.UserName == username && x.UserPassword == password);
                if (user != null)
                {
                    //var UserDetails = UserValidate.GetUserDetails(username, password);
                    var identity = new GenericIdentity(username);
                    //identity.AddClaim(new Claim("Email", UserDetails.Email));
                    //identity.AddClaim(new Claim("Role", roles));
                    identity.AddClaim(new Claim(ClaimTypes.Role, user.Roles));
                    //identity.AddClaim(new Claim("Name", UserDetails.UserName));
                    //identity.AddClaim(new Claim("ID", Convert.ToString(UserDetails.ID)));
                    //IPrincipal principal = new GenericPrincipal(identity, UserDetails.Roles.Split(','));
                    IPrincipal principal = new GenericPrincipal(identity, user.Roles.Split(','));
                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
       
    }
}