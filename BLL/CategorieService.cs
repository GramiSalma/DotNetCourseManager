
using DAL.Entity;
using DAL.Repos;
using Models.Categorie;


namespace BLL
{
    public class CategorieService
    {
        public List<ListCategorieVM> ListCategorieVM()
        {
            //Pour recupere la liste des categorie
            var categorieRepos = new CategorieRepos();


            List<ListCategorieVM> listViewModels = new List<ListCategorieVM>();

            foreach (var item in categorieRepos.All())
            {
                ListCategorieVM categorieListViewModel = new ListCategorieVM();
                categorieListViewModel.Idcategorie = item.Idcategorie;
                categorieListViewModel.Titrecategorie = item.Titrecategorie;
                listViewModels.Add(categorieListViewModel);
            }

            return listViewModels;
        }

        public int AjouterCategorie(string titre)
        {
            CategorieRepos repos = new CategorieRepos();
            Categorie categorie = new Categorie()
            {
                
                Titrecategorie = titre,
               
            };

            // Appeler le Repository pour ajouter le commentaire dans la base de données
            return repos.Create(categorie);
        }
        public void Ajouter(Models.Categorie.ListCategorieVM obj)
        {

            var categorieRepos = new CategorieRepos();
            Categorie categorie = new Categorie
            {
                Titrecategorie = obj.Titrecategorie
                 
            };
            categorieRepos.Create(categorie);

        }
        public void Modifier(Models.Categorie.ListCategorieVM obj)
              
        {
            var categorieRepos = new CategorieRepos();


            Categorie categorieAModifier = categorieRepos.GetById(obj.Idcategorie);




            categorieAModifier.Titrecategorie = obj.Titrecategorie;

            categorieRepos.Update(categorieAModifier);



        }
        public ListCategorieVM Detail(int id)
        {
            var source = new CategorieRepos();
            var objSource = source.Read(id);


            ListCategorieVM obj = new ListCategorieVM();


            obj.Idcategorie = objSource.Idcategorie;
            obj.Titrecategorie = objSource.Titrecategorie;
            


            return obj;
        }
        public void Supprimer(int id)
        {
            var categorieRepos = new CategorieRepos();
            categorieRepos.Delete(id);

        }
        public ListCategorieVM Trouver(int id)
        {
            var source = new CategorieRepos();
            var objSource = source.Read(id);
            ListCategorieVM nouveau = new ListCategorieVM();
            nouveau.Idcategorie = id;
            nouveau.Titrecategorie=objSource.Titrecategorie;



            return nouveau;
        }
        public int NombreTotalCategories()
        {
            var categorieRepos = new CategorieRepos();

            // Utilisez la méthode Count du repository pour obtenir le nombre total de catégories
            return categorieRepos.Count();
        }
        public int NombreCoursParCategorie(int idCategorie)
        {
            var coursRepos = new CoursRepos();

            // Utilisez la méthode Count du repository pour obtenir le nombre de cours pour une catégorie spécifique
            return coursRepos.CountByCategorie(idCategorie);
        }
       
    }
} 

