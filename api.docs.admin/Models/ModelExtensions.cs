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
                           Name = viewModel.Name,
                           ResourceDocs = viewModel.ResourceDocs.ToModelList()
                       };
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

        public static ResourceDoc ToModel(this ResourceDocViewModel viewModel)
        {
            return new ResourceDoc()
                       {
                           Id = viewModel.Id,
                           ResourceId = viewModel.ResourceId,
                           Language = viewModel.Language,
                           Region = viewModel.Region,
                           Summary = viewModel.Summary
                       };
        }

        public static IList<ResourceDoc> ToModelList(this IEnumerable<ResourceDocViewModel> models)
        {
            return models.Select(model => model.ToModel()).ToList();
        }

        public static ResourceDocViewModel ToViewModel(this ResourceDoc model)
        {
            return new ResourceDocViewModel()
                       {
                           Id = model.Id,
                           ResourceId = model.ResourceId,
                           Language = model.Language,
                           Region = model.Region,
                           Summary = model.Summary
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