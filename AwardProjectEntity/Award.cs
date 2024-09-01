using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AwardProjectEntity.Base;

namespace AwardProjectEntity
{
    public class Award : BaseEntity
    {
        [Display(Name = "Başarım Adı")]
        public string Name { get; set; }

        [Display(Name = "Kategori")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Çerçevenin Rengi")]
        public string BorderColor { get; set; }

        [Display(Name = "İkon Rengi")]
        public string FontColor { get; set; }

        [Display(Name = "İkon Sınıfı")]
        public string FontClass { get; set; }

        public Category Category { get; set; }
    }
}
