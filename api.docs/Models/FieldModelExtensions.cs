using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.docs.data;

namespace api.docs.Models
{
    public static class FieldModelExtensions
    {
        public static FieldViewModel ToViewModel(this Field model)
        {
            return new FieldViewModel()
                       {
                           Name = model.Name,
                           FieldType = model.FieldType,
                           FieldDocs = model.FieldDocs.ToViewModelList()
                       };
        }

        public static IList<FieldViewModel> ToViewModelList(this IEnumerable<Field> models)
        {
            return models.Select(f => f.ToViewModel()).ToList();
        }

        public static FieldDocViewModel ToViewModel(this FieldDoc model)
        {
            return new FieldDocViewModel()
                       {
                           Language = model.Language,
                           Description = model.Description
                       };
        }

        public static IList<FieldDocViewModel> ToViewModelList(this IEnumerable<FieldDoc> models)
        {
            return models.Select(fd => fd.ToViewModel()).ToList();
        }
    }
}