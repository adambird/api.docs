using System.Collections.Generic;
using System.Linq;
using api.docs.data;

namespace api.docs.admin.Models
{
    public static class ModelExtensions
    {
        public static Resource ToModel(this ResourceViewModel viewModel)
        {
            return new Resource()
                       {
                           Id = viewModel.Id,
                           Name = viewModel.Name
                       };
        }

        public static IEnumerable<ResourceViewModel> ToViewModelList(this IEnumerable<Resource> models)
        {
            return models.Select(model => model.ToViewModel()).ToList();
        }

        public static ResourceViewModel ToViewModel(this Resource model)
        {
            return new ResourceViewModel()
                       {
                           Id = model.Id,
                           Name = model.Name
                       };
        }
    }
}