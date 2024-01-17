using System.ComponentModel.DataAnnotations;

namespace Maxim1.Areas.Admin.ViewModels
{
    public class ServiceUpdateVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public string ImgUrl { get; set; }
    }
}
