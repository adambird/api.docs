using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.docs.data;

namespace api.docs.admin.Models.Extensions
{
    public static class FieldExtensions
    {
        public static void MapOntoModel(this FieldViewModel viewModel, ref Field model)
        {
            model.Name = viewModel.Name;
            model.FieldType = viewModel.FieldType;
        }

        public static IList<FieldViewModel> ToViewModelList(this IEnumerable<Field> models)
        {
            return models.Select(model => model.ToViewModel()).ToList();
        }

        public static FieldViewModel ToViewModel(this Field model)
        {
            return new FieldViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                FieldType = model.FieldType,
                FieldDocs = model.FieldDocs.ToViewModelList()
            };
        }

    }
}