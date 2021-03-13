using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Web.Areas.Admin.Models
{
    public class EmergencyAddViewModel
    {
        [Display(Name ="Tanım")]
        [Required(ErrorMessage ="Tanım alanı boş geçilemez")]
        public string Definition { get; set; }
    }
}
