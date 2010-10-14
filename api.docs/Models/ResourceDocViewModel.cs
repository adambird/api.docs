using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.docs.Models
{
    public class ResourceDocViewModel
    {
        public Guid Id { get; set; }
        public string CultureString { get; set; }
        public string Language { get; set; }
        public string Region { get; set; }
        public string Summary { get; set; }
    }
}