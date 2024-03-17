using DAL.Entity;
using DAL.Repos;
using Models.Authentification;



namespace BLL
{
    public class AdminService
    {
        public AdminSessionVM? VerifierCompte(AdminAuthVM obj)
        {
            AdminRepos utilisateurRepos = new AdminRepos();
            var result = utilisateurRepos.All()
                        .Where(a => a.MotPasse == obj.MotPasse && a.Compte == obj.Compte)
                        .FirstOrDefault();
            if (result != null)
            {
                AdminSessionVM userSession = new AdminSessionVM();
                userSession.AdresseMail = result.Compte;
                userSession.Id = result.Id;
                userSession.Nom = result.Nom;
                return userSession;
            }
            return null;
        }
        public void Create(AdminVM obj)
        {
            var source = new AdminRepos();
            Admin admin = new Admin();

            admin.Nom = obj.Nom;
            admin.Prenom = obj.Prenom;
            admin.Compte = obj.Compte;
            admin.MotPasse=obj.MotPasse;
            source.Create(admin);
           
        }
    }
}
