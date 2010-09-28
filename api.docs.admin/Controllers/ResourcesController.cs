using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                return View(repository.GetAll());
            }
        }

        //
        // GET: /Resource/Details/5

        public ActionResult Details(int id)
        {
            using (var repository = new ResourceRepository())
            {
                return View(repository.GetById(id));
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Resource/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Resource/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
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
            return View();
        }

        //
        // POST: /Resource/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
