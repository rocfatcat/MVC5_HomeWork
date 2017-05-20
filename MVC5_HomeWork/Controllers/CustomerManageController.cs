using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5_HomeWork.Models;

namespace MVC5_HomeWork.Controllers
{
    public class CustomerManageController : Controller
    {
        private 客戶列表Repository 客戶列表Repo = RepositoryHelper.Get客戶列表Repository();
        // GET: CustomerManage
        public ActionResult Index()
        {
            return View(客戶列表Repo.All());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
