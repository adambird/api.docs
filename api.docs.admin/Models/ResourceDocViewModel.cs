using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.docs.admin.Models
{
    public class ResourceDocViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Language { get; set; }
        public string Region { get; set; }

        [Required]
        [StringLength(1000)]
        public string Summary { get; set; }

        public string CultureString { get; set; }
    }
}