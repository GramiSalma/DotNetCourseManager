using DAL.Entity;
using DAL.Repos;
using Microsoft.Identity.Client;
using Models.Categorie;
using Models.Cours;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace BLL
{

    public class CoursService
    {
        public List<ListCoursVM> ListCoursVM()
        {
            //Pour recupere la liste des categorie
            var coursRepos = new CoursRepos();


            List<ListCoursVM> listViewModels = new List<ListCoursVM>();

            foreach (var item in coursRepos.All())
            {
                ListCoursVM CoursListViewModel = new ListCoursVM();
                CoursListViewModel.Idcours = item.Idcours;
                CoursListViewModel.Titre = item.Titre;
                CoursListViewModel.Description = item.Description;
                CoursListViewModel.Etapes = item.Etapes;
                CoursListViewModel.Idcategorie = item.Idcategorie;
                listViewModels.Add(CoursListViewModel);
            }

            return listViewModels;
        }
        public ListCoursVM Detail(int id)
        {     
            var source = new CoursRepos();
            var objSource = source.Read(id);


            ListCoursVM obj = new ListCoursVM();


            obj.Idcours = objSource.Idcours;
            obj.Description = objSource.Description;
            obj.Titre = objSource.Titre;

            obj.Etapes = objSource.Etapes;

            obj.Date = objSource.Date;

            obj.Idcategorie = objSource.Idcategorie;



            return obj;
        }
        public List<Models.Cours.ListCoursVM> ListParCategorie(int idCategorie)
        {
            var list = new List<Models.Cours.ListCoursVM>();

            //Phase 1 

            CoursRepos repos = new CoursRepos();



            foreach (var item in repos.ReadAll().Where(a => a.Idcategorie == idCategorie))
            {
                ListCoursVM obj = new ListCoursVM()
                { Idcours = item.Idcours, Titre = item.Titre, Description = item.Description, Date = item.Date, Etapes = item.Etapes, Idcategorie = item.Idcategorie };
                list.Add(obj);
            }

            return list;

        }
        public int AjouterCours(string Titre, string Description, string Etapes, int Idcategorie)
        {
            CoursRepos repos = new CoursRepos();
            Cours cours = new Cours()
            {

                Titre = Titre,
                Description = Description,
                Etapes = Etapes,
                Date = DateTime.Now,
                Idcategorie = Idcategorie

            };

            // Appeler le Repository pour ajouter le commentaire dans la base de données
            return repos.Create(cours);
        }
        public void Create(ListCoursVM obj)
        {
            var source = new CoursRepos();
            Cours cours = new Cours();
            cours.Titre = obj.Titre;
            cours.Description = obj.Description;
            cours.Etapes = obj.Etapes;
            cours.Date = DateTime.Now;
            cours.Idcategorie = obj.Idcategorie;

            source.Create(cours);
        }
        public void Modifier(Models.Cours.ListCoursVM obj)

        {
            var coursRepos = new CoursRepos();


            Cours coursAModifier = coursRepos.GetById(obj.Idcours);




            coursAModifier.Titre = obj.Titre;
            coursAModifier.Description = obj.Description;
            coursAModifier.Etapes = obj.Etapes;
            coursAModifier.Idcategorie = obj.Idcategorie;


            coursRepos.Update(coursAModifier);



        }
        public void Supprimer(int id)
        {
            var coursRepos = new CoursRepos();

            coursRepos.Delete(id);

        }
        public ListCoursVM Trouver(int id)
        {
            var source = new CoursRepos();
            var objSource = source.Read(id);
            ListCoursVM nouveau = new ListCoursVM();
            nouveau.Idcours = objSource.Idcours;
            nouveau.Titre = objSource.Titre;
            nouveau.Description = objSource.Description;
            nouveau.Date = objSource.Date;
            nouveau.Etapes = objSource.Etapes;
            nouveau.Idcategorie = objSource.Idcategorie;




            return nouveau;
        }
        public int NombreTotalCours()
        {
            var coursRepos = new CoursRepos();

            // Utilisez la méthode Count du repository pour obtenir le nombre total de cours
            return coursRepos.Count();
        }
        public int NombreCommentairesParCours(int idCours)
        {
            var commentaireRepos = new CommentaireRepos();

            // Utilisez la méthode Count du repository pour obtenir le nombre de commentaires pour un cours spécifique
            return commentaireRepos.CountByCours(idCours);
        }
        public string Nomcat(int id)
        {
            var coursRepos = new CoursRepos();

            return coursRepos.GetCategoryNameForCourse(id);
        }

    }
   
}

        