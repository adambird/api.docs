using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.docs.admin.Models
{
    public class HomePageViewModel
    {
        public IList<ResourceViewModel> Resources { get; set; }
    }
}