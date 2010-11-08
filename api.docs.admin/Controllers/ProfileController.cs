using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace api.docs.admin.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        public ActionResult ChangeCulture(string culture, string redirectUrl)
        {
            Response.AppendCookie(new HttpCookie("culture", culture));
            return new RedirectResult(redirectUrl);
        }

    }
}
