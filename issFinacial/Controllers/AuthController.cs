using issFinacial.Models;
using issFinacial.SQLHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace issFinacial.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.LoginView loginView, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                SQLHelper.SQLHelper objHelper = new SQLHelper.SQLHelper();
                SqlCommand objCommand = new SqlCommand();
                QueryBuilder objBuilder = new QueryBuilder();
                objCommand = objHelper.GetSqlQueryCommand(objBuilder.BuildQuery("login"));
                objHelper.AddInParameter(objCommand, "username", SqlDbType.VarChar, loginView.username);
                objHelper.AddInParameter(objCommand, "Password", SqlDbType.NVarChar, loginView.password);
                objHelper.AddInParameter(objCommand, "cCode", SqlDbType.NVarChar, loginView.companyCode);
                DataTable dtResult = objHelper.LoadDataTable(objCommand, "login");
                if (dtResult.Rows.Count > 0)
                {
                    UserDetails userModel = new Models.UserDetails()
                    {
                        Id = Convert.ToInt32(dtResult.Rows[0]["Id"].ToString()),
                        companyName = dtResult.Rows[0]["CompanyName"].ToString(),
                        Email = dtResult.Rows[0]["Email"].ToString(),
                        Role = dtResult.Rows[0]["RoleName"].ToString(),
                        connectionString = dtResult.Rows[0]["ConnectionString"].ToString()

                    };
                    string userData = JsonConvert.SerializeObject(userModel);
                    FormsAuthenticationTicket authTicket =
                        new FormsAuthenticationTicket(1, loginView.username, DateTime.Now, DateTime.Now.AddMinutes(30), false, userData);

                    string enTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie("issFin", enTicket);
                    Response.Cookies.Add(faCookie);
                }

                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Something Wrong : Username or Password invalid ^_^ ");
            return View(loginView);
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("issFin", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Auth", null);
        }
    }
}