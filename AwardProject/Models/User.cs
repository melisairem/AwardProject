using System.ComponentModel.DataAnnotations.Schema;

namespace AwardProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [NotMapped]
        public string NameSurname
        {
            get
            {
                return Name + " " + Surname.ToUpper();
            }
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
