using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AwardProject.Models.Base;

namespace AwardProject.Models
{
    public class User : BaseEntity 
    {
        [DisplayName("Adı")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Soyadı")]
        [Required]
        public string Surname { get; set; }

        [NotMapped]
        public string NameSurname
        {
            get
            {
                return Name + " " + Surname.ToUpper();
            }
        }

        [DisplayName("E-posta")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required]
        public string Password { get; set; }

    }
}
