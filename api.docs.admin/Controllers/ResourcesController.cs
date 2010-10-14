using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api.docs.admin.Models;
using api.docs.data;
using api.docs.data.Repository;

namespace api.docs.admin.Controllers
{
    public class ResourcesController : Controller
    {
        //
        // GET: /Resource/

        public ActionResult Index()
        {
            using (var repository = new ResourceRepository())
            {
                return View(repository.GetAll().ToViewModelList());
            }
        }

        //
        // GET: /Resource/Details/5

        public ActionResult Details(Guid id)
        {
            using (var repository = new ResourceRepository())
            {
                return View(repository.GetById(id).ToViewModel());
            }
        }

        //
        // GET: /Resource/Create

        public ActionResult Create()
        {
            var viewModel = new ResourceViewModel();
            viewModel.ResourceDocs = new List<ResourceDocViewModel>();
            viewModel.ResourceDocs.Add(new ResourceDocViewModel());

            return View(viewModel);
        } 

        //
        // POST: /Resource/Create

        [HttpPost]
        public ActionResult Create(ResourceViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var repository = new ResourceRepository())
                    {
                        var model = new Resource();
                        viewModel.MapOntoModel(model);
                        repository.Add(model);
                        repository.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(viewModel);
                }
            }
            catch
            {
                return View(viewModel);
            }
        }
        
        //
        // GET: /Resource/Edit/5
 
        public ActionResult Edit(Guid id)
        {
            using (var repository = new ResourceRepository())
            {
                return View(repository.GetById(id).ToViewModel());
            }
        }

        //
        // POST: /Resource/Edit/5

        [HttpPost]
        public ActionResult Edit(ResourceViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var repository = new ResourceRepository())
                    {
                        var resource = repository.GetById(viewModel.Id);
                        viewModel.MapOntoModel(resource);
                        repository.Save(resource);
                        repository.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(viewModel);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Resource/Delete/5
 
        public ActionResult Delete(Guid id)
        {
            using (var repository = new ResourceRepository())
            {
                return View(repository.GetById(id).ToViewModel());
            }
        }

        //
        // POST: /Resource/Delete/5

        [HttpPost]
        public ActionResult Delete(ResourceViewModel viewModel)
        {
            try
            {
                using (var repository = new ResourceRepository())
                {
                    repository.DeleteById(viewModel.Id);
                    repository.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateResourceDoc(ResourceViewModel viewModel)
        {
            //if (ModelState.IsValid)
            //{
                using (var repository = new ResourceRepository())
                {
                    var resource = repository.GetById(viewModel.Id);
                    var doc = new ResourceDoc();
                    viewModel.NewDoc.MapOntoModel(doc);
                    resource.ResourceDocs.Add(doc);
                    repository.SaveChanges();
                }
                return RedirectToAction("Edit", new { id = viewModel.Id });
            //}
            //else
            //{
            //    return View("Edit", viewModel);
            //}

        }

    }
}
