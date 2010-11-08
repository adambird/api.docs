using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.docs.data;

namespace api.docs.Models
{
    public class ResourceViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<ResourceDocViewModel> ResourceDocs { get; set; }

        public ResourceDocViewModel GetDoc(string language)
        {
            return ResourceDocs.SingleOrDefault(rd => rd.Language == language) ??
                      ResourceDocs.Single(rd => rd.Language == Configuration.DefaultLanguage);
        }

        public IList<FieldViewModel> Fields { get; set; }

    }
}