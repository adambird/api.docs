using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.docs.admin.Models
{
    public class ResourceDocViewModel
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }

        [Required]
        public string Language { get; set; }
        public string Region { get; set; }

        [Required]
        [StringLength(1000)]
        public string Summary { get; set; }
    }
}