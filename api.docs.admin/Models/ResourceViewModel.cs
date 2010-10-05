﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.docs.admin.Models
{
    public class ResourceViewModel
    {
        public int Id { get; set; }

        [Required()]
        [StringLength(100)]
        public string Name { get; set; }

        public IList<ResourceDocViewModel> ResourceDocs { get; set; }

        public ResourceDocViewModel NewDoc { get; set; }

        public ResourceViewModel()
        {
            NewDoc = new ResourceDocViewModel();
        }
    }
}