using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api.docs.admin.Models;
using api.docs.data.Repository;
using Ninject;

namespace api.docs.admin.Controllers
{
    public class ResourceDocsController : Controller
    {
        private readonly IResourceDocRepository _resourceDocRepository;

        [Inject]
        public ResourceDocsController(IResourceDocRepository resourceDocRepository)
        {
            _resourceDocRepository = resourceDocRepository;
        }

        //
        // GET: /ResourceDocs/

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Resources");
        }

        //
        // GET: /ResourceDocs/Edit/5
 
        public ActionResult Edit(Guid id)
        {
            var resourceDoc = _resourceDocRepository.GetById(id);
            if (resourceDoc == null) throw new HttpException(404, "");
            return View(resourceDoc.ToViewModel());
        }

        //
        // POST: /ResourceDocs/Edit/5

        [HttpPost]
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
