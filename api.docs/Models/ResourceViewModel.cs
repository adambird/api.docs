using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.docs.Models
{
    public class ResourceViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<ResourceDocViewModel> ResourceDocs { get; set; }
    }
}