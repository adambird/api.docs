using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api.docs.admin.Models;
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

        public ActionResult Details(int id)
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
            return View();
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
                        repository.Add(viewModel.ToModel());
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
 
        public ActionResult Edit(int id)
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
                        resource.Name = viewModel.Name;
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
 
        public ActionResult Delete(int id)
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
                    repository.Delete(viewModel.ToModel());
                    repository.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
