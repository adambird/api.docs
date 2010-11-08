using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.docs.admin.Models
{
    public class ResourceDocViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        public Guid ResourceId { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        [StringLength(1000)]
        public string Summary { get; set; }
    }
}