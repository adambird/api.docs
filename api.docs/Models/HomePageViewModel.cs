using System.Collections.Generic;
using api.docs.data;

namespace api.docs.Models
{
    public class HomePageViewModel
    {
        public IList<ResourceViewModel> Resources { get; set; }
    }
}