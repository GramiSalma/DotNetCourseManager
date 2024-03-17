
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DAL.Entity
{
    [Table("T_Admin")]
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Compte { get; set; } = string.Empty;
        public string MotPasse { get; set; } = string.Empty;
    }
}
