using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwardProject.Models
{
    public class Award
    {
        public int Id { get; set; }

        [Display(Name = "Başarım Adı")]
        public string Name { get; set; }

        [Display(Name = "Kategori")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Çerçevenin Rengi")]
        public string BorderColor { get; set; }

        [Display(Name = "Yazı Rengi")]
        public string FontColor { get; set; }

        [Display(Name = "İkon Sınıfı")]
        public string FontClass { get; set; }

        public Category Category { get; set; }
    }
}
