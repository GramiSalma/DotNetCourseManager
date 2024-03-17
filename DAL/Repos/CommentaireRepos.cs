using DAL.Entity;

namespace DAL.Repos
{
    public class CommentaireRepos
    {
        
        public int Create(Commentaire commentaire)
        {
            MyDbContext db = new MyDbContext();
            db.Commentaire.Add(commentaire);

            return db.SaveChanges();
        }
        public List<Commentaire> ReadAll()
        {
            MyDbContext dbContext = new MyDbContext();
            return dbContext.Commentaire.ToList();
        }
        public Commentaire Read(int id)
        {
            MyDbContext dbContext = new MyDbContext();
            return dbContext.Commentaire.Find(id);
        }
        public void Delete(int id)
        {
            MyDbContext dbContext = new MyDbContext();
            var obj = dbContext.Commentaire.Find(id);
            dbContext.Commentaire.Remove(obj);
        }

        public void Update(Commentaire entity)
        {
            MyDbContext dbContext = new MyDbContext();
            dbContext.Commentaire.Update(entity);
        }
        public int CountByCours(int idCours)
        {
            MyDbContext dbContext = new MyDbContext();
            // Utilisez Entity Framework ou tout autre mécanisme de stockage pour compter le nombre de commentaires pour un cours spécifique
            return dbContext.Commentaire.Count(c => c.Idcours == idCours);
        }
        public string GetCoursNameForComment(int commentId)
        {
            MyDbContext dbContext = new MyDbContext();

            // Recherche du cours par ID
            var comment = dbContext.Commentaire.Find(commentId);

            if (comment != null)
            {
                // Trouver la catégorie associée à ce cours
                var cours= dbContext.Cours.Find(comment.Idcours);

                if (cours != null)
                {
                    // Retourner le nom de la catégorie
                    return cours.Titre;
                }

            }


            // Si le cours ou la catégorie n'est pas trouvé, retournez null ou une valeur par défaut
            return "Rien";

        }
    }
}
