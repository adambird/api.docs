using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.docs.data;

namespace api.docs.admin.Models.Extensions
{
    public static class ResourceExtensions
    {
        public static void MapOntoModel(this ResourceViewModel viewModel, ref Resource model)
        {
            model.Name = viewModel.Name;
        }

        public static IList<ResourceViewModel> ToViewModelList(this IEnumerable<Resource> models)
        {
            return models.Select(model => model.ToViewModel()).ToList();
        }

        public static ResourceViewModel ToViewModel(this Resource model)
        {
            return new ResourceViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                ResourceDocs = model.ResourceDocs.ToViewModelList(),
                Fields = model.Fields.ToViewModelList()
            };
        }
    }
}