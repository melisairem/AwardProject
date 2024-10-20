using AwardProjectEntity.Base;
using System.ComponentModel.DataAnnotations;

namespace AwardProjectEntity
{
    public class Image : BaseEntity
    {
        [Display(Name = "Görselin Adı")]
        public string Name { get; set; }

        [Display(Name = "Görselin Yolu")]
        public string Path { get; set; }
    }
}
