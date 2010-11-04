using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.docs.data;

namespace api.docs.admin.Models.Extensions
{
    public static class ResourceDocExtensions
    {
        public static void MapOntoModel(this ResourceDocViewModel viewModel, ref ResourceDoc model)
        {
            model.Language = viewModel.Language;
            model.Summary = viewModel.Summary;
        }

        public static ResourceDocViewModel ToViewModel(this ResourceDoc model)
        {
            return new ResourceDocViewModel()
            {
                Id = model.Id,
                Language = model.Language,
                Summary = model.Summary,
            };
        }

        public static IDictionary<string, ResourceDocViewModel> ToViewModelList(this IEnumerable<ResourceDoc> models)
        {
            return models == null ? new Dictionary<string, ResourceDocViewModel>() : models.ToDictionary(m => m.Language, m => m.ToViewModel());
        }
    }
}