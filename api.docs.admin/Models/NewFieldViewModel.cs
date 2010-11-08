using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.docs.admin.Models
{
    public class NewFieldViewModel : BaseViewModel
    {
        public Guid ResourceId { get; set; }
        public string Name { get; set; }
        public string FieldType { get; set; }
        public string Description { get; set; }
    }
}