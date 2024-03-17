using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Cours
{
   public class ListCoursVM
    {
        public int Idcours { get; set; }
        public String Titre { get; set; } = string.Empty;
        public String Description { get; set; } = string.Empty;
        public String Etapes { get; set; }
        public DateTime Date { get; set; }
        public int Idcategorie { get; set; }


    }
}




