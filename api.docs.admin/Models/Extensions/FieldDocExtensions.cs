using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.docs.data;

namespace api.docs.admin.Models.Extensions
{
    public static class FieldDocExtensions
    {
        public static void MapOntoModel(this FieldDocViewModel viewModel, ref FieldDoc model)
        {
            model.Language = viewModel.Language;
            model.Description = viewModel.Description;
        }

        public static FieldDocViewModel ToViewModel(this FieldDoc model)
        {
            return new FieldDocViewModel()
            {
                Id = model.Id,
                Language = model.Language,
                Description = model.Description,
            };
        }

        public static IList<FieldDocViewModel> ToViewModelList(this IEnumerable<FieldDoc> models)
        {
            if (models == null)
            {
                return new List<FieldDocViewModel>();
            }
            else
            {
                return models.Select(model => model.ToViewModel()).ToList();
            }
        }
    }
}