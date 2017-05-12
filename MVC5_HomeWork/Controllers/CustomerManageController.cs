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
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: CustomerManage
        public ActionResult Index()
        {
            var 客戶資訊 = db.客戶列表;
            return View(客戶資訊.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
