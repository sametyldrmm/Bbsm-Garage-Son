using Bbsm_Garage_Son.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Session;
using System.Diagnostics.Eventing.Reader;
using Bbsm_Garage_Son.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.DataProtection;
using System.IdentityModel.Tokens.Jwt;

namespace Bbsm_Garage_Son.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService authService;

        private GenerateTokenRequest generate ;
        public HomeController(ILogger<HomeController> logger, IAuthService authService)
        {
            _logger = logger;
            this.authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var generate2 = new GenerateTokenRequest{   Username = login.Mail, Password = login.Password};
            UserLoginResponse result = new UserLoginResponse{};
            if(generate2 != null)
                result = await authService.LoginUserAsync(generate2);
            
            if (result != null)
            {
                Console.WriteLine(result.AuthToken);
                HttpContext.Response.Cookies.Append("auth_token", result.AuthToken);
                HttpContext.Response.Cookies.Append("access_token_expire_date", result.AccessTokenExpireDate.ToString());
                HttpContext.Response.Cookies.Append("id", result.id.ToString());
                
                // // Kullanıcı adı ve şifre bilgileriyle bir Claim listesi oluşturulur
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, login.Mail),
                        new Claim(ClaimTypes.Role, "Standart"),
                        new Claim(ClaimTypes.Role, "Admin"),
                    };

                // // ClaimsIdentity oluşturulur ve CookieAuthenticationDefaults.AuthenticationScheme ile ilişkilendirilir
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // // Cookie özellikleri belirlenir
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false,
                    ExpiresUtc = result.AccessTokenExpireDate
                };

                // // Cookie oluşturulur ve kullanıcı oturum açar
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                ViewBag.id = result.id;
                return RedirectToAction("Index", "MainPage");
            }

            return RedirectToAction("Index", "Home");

        }
    }
}
