using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Models.Commentaire;
using Models.Cours;
using Microsoft.EntityFrameworkCore;

namespace ProjetWeb.Controllers
{
    public class CommentaireController : Controller
    {
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index()

        {
                return View();
          
        }




        [Authorize]
        public ActionResult ListAdmin(int id)
        {
            CommentaireService commentaireService = new CommentaireService();

            CoursService coursService = new CoursService();
            @ViewData["Titre"] = "Commentaires par cours ";
            if (commentaireService.ListParCours(id).Count == 0)
            {
               @ViewData["null"] = "Pas encore de commentaires pour ce cours ";
            }
          
            ViewBag.countparcours = coursService. NombreCommentairesParCours(id);
            return View(commentaireService.ListParCours(id));
        }




        [AllowAnonymous]
        public ActionResult List(int id)
        {
            
            CommentaireService commentaireService = new CommentaireService();
            
            ViewData["TitrePage"] = "Ajouter un commentaire  ";
            ViewData["liste"] = "Commentaires ";
            ViewBag.cours = id;
            if (commentaireService.ListParCours(id).Count==0)
            {
                ViewData["null"] = "Pas encore de Commentaires pour ce cours";
            }
            return View(commentaireService.ListParCours(id));
        }

        public ActionResult Create(int id)
        {
            CategorieService categorieService = new CategorieService();


            TempData["Id"] = id;
          
            ViewData["Titre"] = "Ajouter Un commentaire";



            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListCommentaireVM obj)
        {

            
               int idFromTempData =(int)TempData["Id"];
               obj.Idcours = idFromTempData;

                CommentaireService service = new CommentaireService();
                service.Create(obj);

                return RedirectToAction("List","Commentaire", new { id = idFromTempData });
            
          
        }    
        



     





    }
    }
