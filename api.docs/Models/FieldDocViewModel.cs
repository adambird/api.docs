using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.docs.Models
{
    public class FieldDocViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
    }
}