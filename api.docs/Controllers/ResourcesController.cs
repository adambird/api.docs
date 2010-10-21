using System;
using System.Web.Mvc;
using api.docs.data.Repository;
using api.docs.Models;
using Ninject;

namespace api.docs.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly IResourceRepository _resourceRepository;

        [Inject]
        public ResourcesController(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(_resourceRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
             var model = _resourceRepository.GetById(id);
             return View(model.ToViewModel());
        }
    }
}
