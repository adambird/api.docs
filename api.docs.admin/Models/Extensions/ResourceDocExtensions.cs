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

        public static IList<ResourceDocViewModel> ToViewModelList(this IEnumerable<ResourceDoc> models)
        {
            if (models == null)
            {
                return new List<ResourceDocViewModel>();
            }
            else
            {
                return models.Select(model => model.ToViewModel()).ToList();
            }
        }
    }
}