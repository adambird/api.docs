using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api.docs.admin.Models;
using api.docs.data.Repository;

namespace api.docs.admin.Controllers
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
