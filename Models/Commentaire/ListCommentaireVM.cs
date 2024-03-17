using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Commentaire
{
    public class ListCommentaireVM
    {public int Idcommentaire { get; set; }
     public String Description { get; set; } = string.Empty;
     public DateTime Date { get; set; }
        public int Idcours { get; set; }
        public String Nomuser { get; set; } = string.Empty;

    }
}

