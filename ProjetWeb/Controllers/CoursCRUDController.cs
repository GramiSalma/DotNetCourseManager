using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL.Entity;
using DAL.Repos;
using Models.Cours;
using Microsoft.AspNetCore.Authorization;


namespace ProjetWeb.Controllers
{
    [Authorize]
    public class CoursCRUDController : Controller
    {
        // GET: CoursCRUDController
        public ActionResult Index()
        {
            CoursService coursService = new CoursService();
            ViewBag.count = coursService.NombreTotalCours();
            ViewData["Titre"] = "Nos Cours";
            return View(coursService.ListCoursVM());

        }

        // GET: CoursCRUDController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CoursCRUDController/Create
        public ActionResult Create()
        {
            CategorieService categorieService = new CategorieService();



            ViewData["Titre"] = "Ajouter Un cours";

            ViewBag.ListCate = categorieService.ListCategorieVM();


            return View();
        }

        // POST: CoursCRUDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListCoursVM obj)
        {

            try
            {
                CoursService service = new CoursService();
                service.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoursCRUDController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        public ActionResult RecupererModelEdit(int id)
        {


            ViewData["Titre"]= "Modifier Cours";
            TempData["Idcours"] = id;


            CategorieService categorieService = new CategorieService();
            ViewBag.ListCate = categorieService.ListCategorieVM();
            CoursService tempService = new CoursService();

            return View(tempService.Trouver(id));

        }

        // POST: CoursCRUDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ListCoursVM model)
        {
            try

            {
                Console.WriteLine("La valeur est : "+TempData["Idcours"]);
                int idFromTempData = (int)TempData["Idcours"];
                model.Idcours = idFromTempData;

                CoursService service = new CoursService();
                service.Modifier(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoursCRUDController/Delete/5
        public ActionResult Delete(int id)
        {
            CoursService coursService = new CoursService();
            coursService.Supprimer(id);
            return RedirectToAction(nameof(Index));

        }



    }

}