using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repos
{
    public class CategorieRepos
    {

        public int Create(Categorie categorie)
        {
            MyDbContext db = new MyDbContext();
            db.Categories.Add(categorie);
            return db.SaveChanges();
        }
        public List<Categorie> All()
        {
            MyDbContext dbContext = new MyDbContext();
            return dbContext.Categories.ToList();
        }
        public Categorie Read(int id)
        {
            MyDbContext dbContext = new MyDbContext();
            return dbContext.Categories.Find(id);
        }
        public void Delete(int id)
        { MyDbContext dbContext = new MyDbContext();

            var obj = dbContext.Categories.Find(id);
            if (obj != null)
            {
                // Récupérer les cours associés à la catégorie
                var coursAssociés = dbContext.Cours.Where(c => c.Idcategorie == id).ToList();

                // Supprimer les cours associés
                foreach (var cours in coursAssociés)
                {
                    dbContext.Cours.Remove(cours);
                }

                // Supprimer la catégorie
                dbContext.Categories.Remove(obj);

                // Enregistrer les modifications dans la base de données
                dbContext.SaveChanges();
            }




        }
            

        public void Update(Categorie entity)
        {
            MyDbContext dbContext = new MyDbContext();
            dbContext.Categories.Update(entity);
            dbContext.SaveChanges();
        }
        public Categorie GetById(int id)
        {
            MyDbContext dbContext = new MyDbContext();
            Categorie cat = dbContext.Categories.Find(id); ;
            return cat;
        }
        public int Count()
        {
            MyDbContext dbContext = new MyDbContext();
            // Utilisez Entity Framework ou tout autre mécanisme de stockage pour compter le nombre total de catégories
            return dbContext.Categories.Count();
        }
       

    }
}
