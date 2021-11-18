using issFinacial.Custom;
using issFinacial.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace issFinacial
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            {
                HttpCookie authCookie = Request.Cookies["issFin"];
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    var serializeModel = JsonConvert.DeserializeObject<UserDetails>(authTicket.UserData);

                    CustomPrincipal principal = new CustomPrincipal(authTicket.Name);

                    principal.Id = serializeModel.Id;
                    principal.Name = serializeModel.companyName;
                    principal.Email = serializeModel.Email;
                    principal.Role = serializeModel.Role;
                    principal.connectionString = serializeModel.connectionString;
                    principal.EId = serializeModel.UserId;
                    HttpContext.Current.User = principal;
                }

            }
        }
    }
}
