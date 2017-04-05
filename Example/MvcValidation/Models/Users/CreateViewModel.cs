using System.ComponentModel.DataAnnotations;

namespace MvcValidation.Models.Users
{
    public class CreateViewModel
    {
        [Display(ResourceType = typeof(Resources.ViewModels), Name = "FirstName")]
        [Required(ErrorMessageResourceType = typeof(Resources.ViewModels), ErrorMessageResourceName = "Required")]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(Resources.ViewModels), Name = "LastName")]
        [Required(ErrorMessageResourceType = typeof(Resources.ViewModels), ErrorMessageResourceName = "Required")]
        [StringLength(10, ErrorMessageResourceType = typeof(Resources.ViewModels), ErrorMessageResourceName = "StringLength")]
        public string LastName { get; set; }
    }
}