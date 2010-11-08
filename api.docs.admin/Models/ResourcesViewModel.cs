using System.Collections.Generic;

namespace api.docs.admin.Models
{
    public class ResourcesViewModel : BaseViewModel
    {
        public IList<ResourceViewModel> Resources { get; set; }
    }
}