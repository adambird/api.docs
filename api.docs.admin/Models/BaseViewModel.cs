using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace api.docs.admin.Models
{
    public class BaseViewModel
    {
        public string UserLanguage
        {
            get
            {
                return HttpContext.Current.Request.Cookies["culture"] != null ? HttpContext.Current.Request.Cookies["culture"].Value : CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            }
        }
    }
}