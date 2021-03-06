﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.docs.data;

namespace api.docs.Models
{
    public static class ResourceModelExtensions
    {
        public static ResourceDocViewModel ToViewModel(this ResourceDoc model)
        {
            return new ResourceDocViewModel()
            {
                Id = model.Id,
                Language = model.Language,
                Summary = model.Summary
            };
        }

        public static IList<ResourceViewModel> ToViewModelList(this IEnumerable<Resource> models)
        {
            return models.Select(model => model.ToViewModel()).ToList();
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