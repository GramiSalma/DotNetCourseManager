using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    [Table("Commentaire", Schema = "db")]
    public class Commentaire
    {
        [Key]
        [Column(Order = 0)]
        public int Idcommentaire{ get; set; }


       
        [Display(Name = "Description")]
        [Required]
        [Column(Order = 1, TypeName = "varchar(500)")]
        public String Description { get; set; } = string.Empty;




        [Display(Name = "Nomuser")]
        [Required]
        [Column(Order = 2, TypeName = "varchar(500)")]
        public String Nomuser { get; set; } = string.Empty;

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Column(Order = 3, TypeName = "varchar(250)")]
        public DateTime Date { get; set; }


        public int Idcours { get; set; }
        [ForeignKey("Idcours")]
        public Cours? Cours { get; set; }
       




    }
}
