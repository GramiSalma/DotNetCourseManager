using DAL;
using DAL.Entity;

namespace DAL.Repos
{
    public class CoursRepos
    {
        public int Create(Cours Cours)
        {
            MyDbContext db = new MyDbContext();
            db.Cours.Add(Cours);
            return db.SaveChanges();
        }
        public List<Cours> ReadAll()
        {
            MyDbContext dbContext = new MyDbContext();
            return dbContext.Cours.ToList();
        }
        public Cours Read(int id)
        {
            MyDbContext dbContext = new MyDbContext();
            return dbContext.Cours.Find(id);
        }
        public void Delete(int id)
        {
            MyDbContext dbContext = new MyDbContext();

            var obj = dbContext.Cours.Find(id);
            if (obj != null)
            {
                // Récupérer les cours associés à la catégorie
                var commentairesAssociés = dbContext.Commentaire.Where(c => c.Idcours == id).ToList();

                // Supprimer les cours associés
                foreach (var commentaire in commentairesAssociés)
                {
                    dbContext.Commentaire.Remove(commentaire);
                }

                // Supprimer la catégorie
                dbContext.Cours.Remove(obj);

                // Enregistrer les modifications dans la base de données
                dbContext.SaveChanges();
            }
        }

        public List<Cours> All()
        {
            MyDbContext dbContext = new MyDbContext();
            return dbContext.Cours.ToList();
        }
       
       
        public void Update(Cours entity)
        {
            MyDbContext dbContext = new MyDbContext();
            dbContext.Cours.Update(entity);
            dbContext.SaveChanges();
        }
        public Cours GetById(int id)
        {
            MyDbContext dbContext = new MyDbContext();
            Cours cat = dbContext.Cours.Find(id); ;
            return cat;
        }
        public int Count()
        {
            MyDbContext dbContext = new MyDbContext();
            // Utilisez Entity Framework ou tout autre mécanisme de stockage pour compter le nombre total de cours
            return dbContext.Cours.Count();
        }
       
        public int CountByCategorie(int idCategorie)
        {
            MyDbContext dbContext = new MyDbContext();
            // Utilisez Entity Framework ou tout autre mécanisme de stockage pour compter le nombre de cours pour une catégorie spécifique
            return dbContext.Cours.Count(c => c.Idcategorie == idCategorie);
        }
        public string GetCategoryNameForCourse(int courseId)
        {
            MyDbContext dbContext = new MyDbContext();

            // Recherche du cours par ID
            var course = dbContext.Cours.Find(courseId);

            if (course != null)
            {
                // Trouver la catégorie associée à ce cours
                var category = dbContext.Categories.Find(course.Idcategorie);

                if (category != null)
                {
                    // Retourner le nom de la catégorie
                    return category.Titrecategorie;
                }
            }

            // Si le cours ou la catégorie n'est pas trouvé, retournez null ou une valeur par défaut
            return null;
        }
    }
}


