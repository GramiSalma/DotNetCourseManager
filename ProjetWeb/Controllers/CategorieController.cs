using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL;
using Microsoft.AspNetCore.Authorization;

namespace ProjetWeb.Controllers
{
    public class CategorieController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()

        {

            CategorieService categorieService = new CategorieService();

            ViewData["TitrePage"] = "Nos Catégories ";
            ViewData["DescriptioPage"] = "Description de la page Catégorie";
            

            return View(categorieService.ListCategorieVM());
      
        }
        public ActionResult List(int id)
        {
            CoursService coursService = new CoursService();
            if (coursService.ListParCategorie(id).Count == 0)
            {
                ViewData["null"] = "Pas encore de cours ";
            }
            ViewData["TitrePage"] = "Nos Cours par Catégorie ";
            ViewData["DescriptioPage"] = "Description de la page Catégorie";
            return View(coursService.ListParCategorie(id));
        }
        

    }
}
