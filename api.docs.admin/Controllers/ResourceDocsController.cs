using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api.docs.admin.Models;
using api.docs.data.Repository;

namespace api.docs.admin.Controllers
{
    public class ResourceDocsController : Controller
    {
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
            using (var repository = new ResourceDocRepository())
            {
                var resourceDoc = repository.GetById(id);
                if (resourceDoc == null) throw new HttpException(404, "");
                return View(resourceDoc.ToViewModel());
            }
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
                    using (var repository = new ResourceDocRepository())
                    {
                        var resourceDoc = repository.GetById(viewModel.Id);
                        if (resourceDoc == null) throw new HttpException(404, "");

                        viewModel.MapOntoModel(resourceDoc);
                        repository.Save(resourceDoc);
                        repository.SaveChanges();

                        return RedirectToAction("Details", "Resources", new {id = resourceDoc.Resource.Id});
                    }
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
            using (var repository = new ResourceDocRepository())
            {
                var resourceDoc = repository.GetById(id);
                if (resourceDoc == null) throw new HttpException(404, "");
                return View(resourceDoc.ToViewModel());
            }
        }

        //
        // POST: /ResourceDocs/Delete/5

        [HttpPost]
        public ActionResult Delete(ResourceDocViewModel viewModel)
        {
            try
            {
                using (var repository = new ResourceDocRepository())
                {
                    var resourceDoc = repository.GetById(viewModel.Id);
                    if (resourceDoc == null) throw new HttpException(404, "");

                    repository.DeleteById(resourceDoc.Id);

                    repository.SaveChanges();

                    return RedirectToAction("Details", "Resources", new { id = resourceDoc.Resource.Id });
                }
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
