using System.ComponentModel.DataAnnotations;

namespace Maxim1.Areas.Admin.ViewModels
{
    public class ServiceCreateVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile? Image { get; set; }
    }
}
