using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Web.Areas.Admin.Models
{
    public class JobAddViewModel
    {
        [Required(ErrorMessage ="Ad alanı gereklidir.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="Lütfen bir aciliyet durumu seçiniz")]
        public int EmergencyId { get; set; }

    }
}
