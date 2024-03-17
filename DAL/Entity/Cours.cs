
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DAL.Entity
{
    [Table("Cours", Schema = "db")]
    public class Cours
    {
        [Key]
        [Column(Order =0)]
        public int Idcours { get; set; }


        [Required]
        [Display(Name = "Titre")]
        [Column(Order=1,TypeName = "varchar(200)")]
        public String Titre { get; set; } = string.Empty;


        public String Description { get; set; } = string.Empty;

        [Display(Name = "Etapes")]
        [Column(Order = 2, TypeName = "varchar(250)")]
        public String? Etapes { get; set; }


        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Column(Order = 3, TypeName = "varchar(250)")]
        public DateTime Date { get; set; }


        public int Idcategorie{ get; set; }
        [ForeignKey("Idcategorie")]
        public Categorie? Categorie { get; set;}






    }
}
