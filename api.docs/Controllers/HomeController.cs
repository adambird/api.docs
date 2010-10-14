using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api.docs.data.Repository;
using api.docs.Models;

namespace api.docs.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new HomePageViewModel();

            using (var resourcesRepository = new ResourceRepository())
            {
                model.Resources = resourcesRepository.GetAll().ToViewModelList();
            }

            return View(model);
        }

    }
}
