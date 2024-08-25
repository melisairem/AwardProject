using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwardProject.Models
{
    public class User
    {
        public int Id { get; set; }

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

        public DateTime CreateAt { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
