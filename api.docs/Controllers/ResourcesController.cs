using System.Web.Mvc;
using api.docs.data.Repository;

namespace api.docs.Controllers
{
    public class ResourcesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (var repository = new ResourceRepository())
            {
                return View(repository.GetAll());
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            using (var repository = new ResourceRepository())
            {
                var model = repository.GetById(id);
                return View(model);
            }
        }
    }
}
