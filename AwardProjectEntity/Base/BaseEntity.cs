using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AwardProjectEntity.Base
{
    public abstract class BaseEntity
    { 
        [Key]
        public virtual int Id { get; set; }

        [DisplayName("Oluşturma Tarihi")]
        public DateTime AddDate { get; set; }

        [DisplayName("Güncelleme Tarihi")]
        public DateTime? UpdateDate { get; set; }
    }
}
