using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
        [Table("Categorie", Schema = "db")]
    public class Categorie
    {

     
            [Key]
            [Column(Order =0)]
            public int Idcategorie { get; set; }


            [Required]
            [Display(Order=1,Name = "Categorie")]
            [Column(TypeName = "varchar(200)")]
            public String Titrecategorie { get; set; } = string.Empty;

           

    }
}
