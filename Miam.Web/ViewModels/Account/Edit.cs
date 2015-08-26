using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Miam.Web.ViewModels.Account
{
    public class Edit
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Courriel")]
        [Required(ErrorMessage = "Le champ courriel est requis")]
        public string Email { get; set; }
        
        [DisplayName("Nouveau mot de passe")]
        [Required(ErrorMessage = "Le champ nouveau mot de passe est requis")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        
        [DisplayName("Confirmation du nouveau mot de passe")]
        [Required(ErrorMessage = "Le champ confirmation du nouveau mot de passe est requis")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string RepeatPassword { get; set; }

        [DisplayName("Nom")]
        [Required(ErrorMessage = "Le champ nom est requis")]
        public string Name { get; set; }
    }
}