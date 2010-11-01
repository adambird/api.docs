using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.docs.data;

namespace api.docs.Models
{
    public class FieldViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FieldType { get; set; }

        public IList<FieldDocViewModel> FieldDocs { get; set; }

        public FieldDocViewModel GetDoc(string language)
        {
            return FieldDocs.SingleOrDefault(fd => fd.Language == language) ??
                      FieldDocs.Single(fd => fd.Language == Configuration.DefaultLanguage);
        }
    }
}