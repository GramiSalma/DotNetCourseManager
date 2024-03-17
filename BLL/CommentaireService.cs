using DAL.Repos;
using DAL.Entity;
using Models.Commentaire;
using Models.Cours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL
{
   public class CommentaireService





    { 
 
        public List<Models.Commentaire.ListCommentaireVM> ListParCours(int idCours)
        {
            var list = new List<Models.Commentaire.ListCommentaireVM>();

            //Phase 1 

            CommentaireRepos repos = new CommentaireRepos();



            foreach (var item in repos.ReadAll().Where(a => a.Idcours == idCours))
            {
                ListCommentaireVM obj = new ListCommentaireVM()
                { Idcommentaire = item.Idcommentaire, Description = item.Description, Date = item.Date,Nomuser =item.Nomuser,Idcours=item.Idcours};
                list.Add(obj);
                
            }

            return list;

        }
        public int  AjouterCommentaire(int idCours,string nomUtilisateur, string description)
        {
            CommentaireRepos repos = new CommentaireRepos();
            Commentaire commentaire = new Commentaire()
            {
                Idcours = idCours,
                Description = description,
                    Date = DateTime.Now,
                    Nomuser = nomUtilisateur
                };

                // Appeler le Repository pour ajouter le commentaire dans la base de données
                return repos.Create(commentaire);
            }

        public void Create(ListCommentaireVM obj)
        {
            var source = new CommentaireRepos();
            Commentaire comment = new Commentaire()
            {
                Idcours = obj.Idcours,
                Description = obj.Description,
                Nomuser = obj.Nomuser,
                Date = DateTime.Now
            };
          

            source.Create(comment);
        }
        public string Nomcours(int id)
        {
            var commentaireRepos = new CommentaireRepos();

            return commentaireRepos.GetCoursNameForComment(id);
        }
    }

    

}

    

           
           
