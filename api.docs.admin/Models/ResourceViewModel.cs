using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using api.docs.data;

namespace api.docs.admin.Models
{
    public class ResourceViewModel
    {
        private Guid _id;

        public Guid Id
        {
            get {return _id;} 
            set
            {
                _id = value;
                NewField.ResourceId = _id;
            } 
        }

        [Required()]
        [StringLength(50)]
        public string Name { get; set; }

        public IList<ResourceDocViewModel> ResourceDocs { get; set; }
        public IList<FieldViewModel> Fields { get; set; }

        public ResourceDocViewModel NewDoc { get; set; }
        public NewFieldViewModel NewField { get; set; }

        public ResourceViewModel()
        {
            NewDoc = new ResourceDocViewModel();
            NewField = new NewFieldViewModel();
            ResourceDocs = new List<ResourceDocViewModel>();
            Fields = new List<FieldViewModel>();
        }
    }
}