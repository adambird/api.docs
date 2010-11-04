using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api.docs.admin.Models;
using api.docs.admin.Models.Extensions;
using api.docs.data;
using api.docs.data.Repository;
using Ninject;

namespace api.docs.admin.Controllers
{
    public class ResourceDocsController : Controller
    {
        private readonly IResourceDocRepository _resourceDocRepository;
        private readonly IResourceRepository _resourceRepository;

        [Inject]
        public ResourceDocsController(IResourceDocRepository resourceDocRepository, IResourceRepository resourceRepository)
        {
            _resourceDocRepository = resourceDocRepository;
            _resourceRepository = resourceRepository;
        }

        //
        // GET: /ResourceDocs/
        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Resources");
        }

        [HttpGet]
        public ActionResult Create(Guid resourceId, string language)
        {
            var viewModel = new ResourceDocViewModel()
                                {
                                    ResourceId = resourceId,
                                    Language = language
                                };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ResourceDocViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var resource = _resourceRepository.GetById(viewModel.ResourceId);
                    var resourceDoc = new ResourceDoc()
                                          {
                                              Resource = resource
                                          };
                    viewModel.MapOntoModel(ref resourceDoc);
                    _resourceDocRepository.Add(resourceDoc);
                    _resourceDocRepository.SaveChanges(); 
                    return RedirectToAction("Details", "Resources", new { id = resource.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(viewModel);
        }

        //
        // GET: /ResourceDocs/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var resourceDoc = _resourceDocRepository.GetById(id);
            if (resourceDoc == null) throw new HttpException(404, "");
            return View(resourceDoc.ToViewModel());
        }

        //
        // POST: /ResourceDocs/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ResourceDocViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var resourceDoc = _resourceDocRepository.GetById(viewModel.Id);
                    if (resourceDoc == null) throw new HttpException(404, "");

                    viewModel.MapOntoModel(ref resourceDoc);
                    _resourceDocRepository.Save(resourceDoc);
                    _resourceDocRepository.SaveChanges();

                    return RedirectToAction("Details", "Resources", new {id = resourceDoc.Resource.Id});
                }
                catch (HttpException)
                {
                    throw;
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError("", exception);
                }
            }
            return View(viewModel);
        }

        //
        // GET: /ResourceDocs/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var resourceDoc = _resourceDocRepository.GetById(id);
            if (resourceDoc == null) throw new HttpException(404, "");
            return View(resourceDoc.ToViewModel());
        }

        //
        // POST: /ResourceDocs/Delete/5

        [HttpPost]
        public ActionResult Delete(ResourceDocViewModel viewModel)
        {
            try
            {
                var resourceDoc = _resourceDocRepository.GetById(viewModel.Id);
                if (resourceDoc == null) throw new HttpException(404, "");

                _resourceDocRepository.DeleteById(resourceDoc.Id);

                _resourceDocRepository.SaveChanges();

                return RedirectToAction("Details", "Resources", new { id = resourceDoc.Resource.Id });
            }
            catch (HttpException)
            {
                throw;
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception);
            }

            return View(viewModel);
        }
    }
}
