using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcModels.App_GlobalResources;

namespace MvcModels.Models.Users
{
    public class CreateViewModel
    {
        [Display(ResourceType = typeof(Resources.ViewModels), Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(Resources.ViewModels), Name = "LastName")]
        public string LastName { get; set; }
    }
}