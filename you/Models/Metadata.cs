using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace you.Models
{
    [MetadataType(typeof(Usermetadata))]
    public partial class User
    {
        [Required(ErrorMessage = "Nem lehet üres!", AllowEmptyStrings = false)]
        [System.Web.Mvc.Remote("IsUsernameAvaliable", "Manage",ErrorMessage ="Érvénytelen felhasználónév!")]
        public string Username { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Required(ErrorMessage = "Nem lehet üres!", AllowEmptyStrings = false)]
        public string Password { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Compare("Password", ErrorMessage = "A két jelszó nem egyezik meg!")]
        [Display(Name="Jelszó megerősítés")]
        public string RPassword { get; set; }
    }

    public partial class Usermetadata
    {
        [Required(ErrorMessage = "Nem lehet üres!", AllowEmptyStrings =false)]
        [DisplayName("Név")]
        public string Name { get; set; }
        [DisplayName("Cím")]
        [Required(ErrorMessage = "Nem lehet üres!", AllowEmptyStrings = false)]
        public string Address { get; set; }
        [DisplayName("Nem")]
        [Required(ErrorMessage = "Nem lehet üres!", AllowEmptyStrings = false)]
        public string Gender { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Nem lehet üres!", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage ="Érvénytelen e-mail cím!")]
        public string Email { get; set; }
        [DisplayName("Megye")]
        [Required(ErrorMessage = "Nem lehet üres!", AllowEmptyStrings = false)]
        [Display(Name="District")]
        public Nullable<int> DistrictID { get; set; }
    }

    [MetadataType(typeof(LoginMetadata))]
    public partial class Login
    {

    }

    public partial class LoginMetadata
    {
        [DisplayName("Felhasználónév")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Jelszó")]
        public string Password { get; set; }
    }
}