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
    public class HomeController : Controller
    {
        private readonly IResourceRepository _resourceRepository;

        [Inject]
        public HomeController(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }
        
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new HomePageViewModel()
                            {
                                Resources = _resourceRepository.GetAll().ToViewModelList()
                            };

            return View(model);
        }

    }
}
