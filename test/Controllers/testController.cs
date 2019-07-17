using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using test.Services;

namespace test.Controllers
{
    public class testController : Controller
    {
        // GET: test
        public ActionResult index()
        {
            var service = new Workflow();
            string pid = service.test(); 
            return Content(pid);
        }

    }
}