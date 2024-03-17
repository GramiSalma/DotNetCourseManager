using BLL;
using DAL.Entity;
using DAL.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models.Categorie;

namespace ProjetWeb.Controllers
{
    [Authorize]
    public class CategorieCRUDController : Controller
    {
        // GET: CategorieCRUDController
        [Authorize]
        public ActionResult Index()
        {
            CategorieService categorieService = new CategorieService();

            ViewData["TitrePage"] = "Nos Catégories ";
       
            ViewBag.count = categorieService.NombreTotalCategories();
            
         
            return View(categorieService.ListCategorieVM());
        }

        // GET: CategorieCRUDController/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            CategorieService categorieService = new CategorieService();

            ViewData["TitrePage"] = "Nos Cours par categorie ";

            return View(categorieService.ListCategorieVM());
        }
        [Authorize]
        // GET: CategorieCRUDController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategorieCRUDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListCategorieVM model)
        {
            try
            {
                CategorieService service = new CategorieService();
                service.Ajouter(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }


        [Authorize]
        public ActionResult RecupererIdEdit(int id)
        {
            TempData["MaVariable"] = id;
          CategorieService tempService = new CategorieService();
          
            return View (tempService.Trouver(id));

           
        }

        // GET: CategorieCRUDController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }



        // POST: CategorieCRUDController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editer(ListCategorieVM model)
        {
            try

            {
                var idFromTempData = (int)TempData["MaVariable"];
                model.Idcategorie = idFromTempData;
                CategorieService service = new CategorieService();
                service.Modifier(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        // GET: CategorieCRUDController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
            {
                CategorieService categorieService = new CategorieService();
                categorieService.Supprimer(id);

                return RedirectToAction(nameof(Index));

        }




        [Authorize]
        public ActionResult Detail(int id)
        {
            CoursService coursService = new CoursService();

            ViewData["TitrePage"] = "Nos Cours par Catégorie ";
            if (coursService.ListParCategorie(id).Count == 0)
            {
                 ViewData["null"] = "pas encore de cours";
            }
           


            CategorieService categorieService = new CategorieService();
            ViewBag.countcat = categorieService.NombreCoursParCategorie(id);
            

            return View(coursService.ListParCategorie(id));
        }
    }

       
    }
    
    

