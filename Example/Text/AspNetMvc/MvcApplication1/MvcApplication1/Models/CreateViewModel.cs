using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class CreateViewModel
    {
        [Display(ResourceType = typeof(ViewModels), Name = "UserName")]
        [Required(ErrorMessageResourceType = typeof(ViewModels), ErrorMessageResourceName = "Required")]
        public string UserName { get; set; }

        [Display(ResourceType = typeof(ViewModels), Name = "DisplayName")]
        public string DisplayName { get; set; }
    }
}