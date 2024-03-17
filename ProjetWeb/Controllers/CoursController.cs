using BLL;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ProjetWeb.Controllers
{

    public class CoursController : Controller
    {
        [AllowAnonymous] 
        public IActionResult Details(int id)
        {
            if (id == null) { return NotFound(); }

            CoursService cours = new CoursService();

           ViewData["TitrePage"] = "Contenu ducours ";
           ViewData["DescriptioPage"] = "Etapes du cours";

           return View(cours.Detail(id));
        }
       
    }
}




