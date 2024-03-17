using Models.Authentification;
using System.Security.Claims;
using BLL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Models.Categorie;

namespace Admin.Controllers
{

    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Titre"] = "Authentification";
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "CategorieCRUD");
            return View();

        }

        [HttpPost]
        public IActionResult Index(AdminAuthVM model)
        {
            AdminService utilisateurService = new AdminService();
            var us = utilisateurService.VerifierCompte(model);
           
            if (us != null)
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.Email, us.AdresseMail),
                    new Claim("Role","Admin"),
                    new Claim(ClaimTypes.NameIdentifier, us.Id.ToString()),
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {

                    AllowRefresh = true,
                    //IsPersistent = us.KeepLoggedIn
                };

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "CategorieCRUD");
            }



            ViewData["ValidateMessage"] = "Les informations sont erronees";
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        // GET: AdminController/Create
        public ActionResult Create()
        {
            ViewData["Titre"] = "Ajouter un nouvel Administrateur";
            return View();
        }

        // POST: Adminontroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdminVM model)
        {
            try
            {
                AdminService service = new AdminService();
                service.Create(model);
              

                return RedirectToAction("Index", "CategorieCRUD");
            }
            catch
            {
                return View();
            }

        }

    }
}
 