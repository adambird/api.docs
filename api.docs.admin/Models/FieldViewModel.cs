﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.docs.admin.Models
{
    public class FieldViewModel
    {
        public Guid Id { get; set; }

        [Required()]
        [StringLength(50)]
        public string Name { get; set; }

        [Required()]
        [StringLength(100)]
        public string FieldType { get; set; }

        public IList<FieldDocViewModel> FieldDocs { get; set; }

        public FieldDocViewModel NewDoc { get; set; }

        public FieldViewModel()
        {
            NewDoc = new FieldDocViewModel();
        }

    }
}