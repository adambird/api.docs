using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api.docs.admin.Models;
using api.docs.admin.Models.Extensions;
using api.docs.data;
using api.docs.data.Repository;
using log4net;
using Ninject;

namespace api.docs.admin.Controllers
{
    public class ResourcesController : Controller
    {
        private static ILog _logger = LogManager.GetLogger(typeof(ResourcesController));

        private readonly IResourceRepository _resourceRepository;

        [Inject]
        public ResourcesController(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }
        
        //
        // GET: /Resource/
        [HttpGet]
        public ActionResult Index()
        {
            return View(_resourceRepository.GetAll().ToViewModelList());
        }

        //
        // GET: /Resource/Details/5

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            return View(_resourceRepository.GetById(id).ToViewModel());
        }

        //
        // GET: /Resource/Create

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new ResourceViewModel()
                                {
                                    ResourceDocs = new List<ResourceDocViewModel>() {new ResourceDocViewModel()}
                                };

            return View(viewModel);
        } 

        //
        // POST: /Resource/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ResourceViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new Resource();
                    viewModel.MapOntoModel(ref model);
                    _resourceRepository.Add(model);
                    _resourceRepository.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(viewModel);
                }
            }
            catch(Exception ex)
            {
                _logger.Error("ResourcesController.Create", ex);
                ModelState.AddModelError("", ex);
                return View(viewModel);
            }
        }
        
        //
        // GET: /Resource/Edit/5
 
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(_resourceRepository.GetById(id).ToViewModel());
        }

        //
        // POST: /Resource/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ResourceViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resource = _resourceRepository.GetById(viewModel.Id);
                    viewModel.MapOntoModel(ref resource);
                    _resourceRepository.Save(resource);
                    _resourceRepository.SaveChanges();

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
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            return View(_resourceRepository.GetById(id).ToViewModel());
        }

        //
        // POST: /Resource/Delete/5

        [HttpPost]
        public ActionResult Delete(ResourceViewModel viewModel)
        {
            try
            {
                _resourceRepository.DeleteById(viewModel.Id);
                _resourceRepository.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateResourceDoc(ResourceViewModel viewModel)
        {
            //if (ModelState.IsValid)
            //{
                var resource = _resourceRepository.GetById(viewModel.Id);
                var doc = new ResourceDoc() { Resource = resource };
                viewModel.NewDoc.MapOntoModel(ref doc);
                resource.ResourceDocs.Add(doc);
                _resourceRepository.SaveChanges();

                return RedirectToAction("Edit", new { id = viewModel.Id });
            //}
            //else
            //{
            //    return View("Edit", viewModel);
            //}

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateField(ResourceViewModel viewModel)
        {
            //if (ModelState.IsValid)
            //{
            var resource = _resourceRepository.GetById(viewModel.Id);
            var field = new Field()
                            {
                                Resource = resource,
                                Name = viewModel.NewField.Name,
                                FieldType = viewModel.NewField.FieldType
                            };

            field.FieldDocs.Add(new FieldDoc()
                                    {
                                        Language = Configuration.DefaultLanguage,
                                        Description = viewModel.NewField.Description,
                                        Field = field
                                    });

            resource.Fields.Add(field);

            _resourceRepository.Save(resource);
            _resourceRepository.SaveChanges();

            return RedirectToAction("Edit", new { id = viewModel.Id });
            //}
            //else
            //{
            //    return View("Edit", viewModel);
            //}

        }

    }
}
