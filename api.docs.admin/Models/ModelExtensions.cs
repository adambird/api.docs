using System.Collections.Generic;
using System.Linq;
using api.docs.data;

namespace api.docs.admin.Models
{
    public static class ModelExtensions
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
                           ResourceDocs = model.ResourceDocs.ToViewModelList()
                       };
        }

        public static void MapOntoModel(this ResourceDocViewModel viewModel, ref ResourceDoc model)
        {
            model.Language = viewModel.Language;
            model.Region = viewModel.Region;
            model.Summary = viewModel.Summary;
        }

        public static ResourceDocViewModel ToViewModel(this ResourceDoc model)
        {
            return new ResourceDocViewModel()
                       {
                           Id = model.Id,
                           Language = model.Language,
                           Region = model.Region,
                           Summary = model.Summary,
                           CultureString = model.CultureString
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