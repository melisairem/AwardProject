using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AwardProjectEntity.Base;

namespace AwardProjectEntity
{
    public class UserAward : BaseEntity
    {
        [Display(Name = "Kullanıcı")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Display(Name = "Başarım Adı")]
        [ForeignKey("Award")]
        public int AwardId { get; set; }

        public User User { get; set; }

        public Award Award { get; set; }
    }
}
