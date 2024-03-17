using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Authentification
{
    public  class AdminVM
    {
      
            public int Id { get; set; }
            public string Nom { get; set; } = string.Empty;
            public string Prenom { get; set; } = string.Empty;
            public string Compte { get; set; } = string.Empty;
            public string MotPasse { get; set; } = string.Empty;
       
    }
}
