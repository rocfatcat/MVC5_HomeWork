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
    public class CustomerBankManageController : Controller
    {

        private 客戶銀行資訊Repository 客戶銀行資訊Repo = RepositoryHelper.Get客戶銀行資訊Repository();
        private 客戶資料Repository 客戶資料Repo;

        public CustomerBankManageController()
        {
            客戶資料Repo = RepositoryHelper.Get客戶資料Repository(客戶銀行資訊Repo.UnitOfWork);
        }
        // GET: CustomerBankManager
        public ActionResult Index()
        {
            var 客戶銀行資訊 = 客戶銀行資訊Repo.All().Where(x => x.刪除 != true);
            return View(客戶銀行資訊.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(客戶銀行資訊SearchModel search)
        {
            var 客戶銀行資訊 = 客戶銀行資訊Repo.All().Where(x => x.刪除 != true);
            if(!string.IsNullOrEmpty(search.分行代碼))
                客戶銀行資訊 = 客戶銀行資訊.Where(x => x.分行代碼.ToString().Contains(search.分行代碼));
            if (!string.IsNullOrEmpty(search.帳戶名稱))
                客戶銀行資訊 = 客戶銀行資訊.Where(x => x.帳戶名稱.Contains( search.帳戶名稱));
            if (!string.IsNullOrEmpty(search.帳戶號碼))
                客戶銀行資訊 = 客戶銀行資訊.Where(x => x.帳戶號碼.Contains(search.帳戶號碼));
            if (!string.IsNullOrEmpty(search.銀行代碼))
                客戶銀行資訊 = 客戶銀行資訊.Where(x => x.銀行代碼.ToString().Contains(search.銀行代碼));
            if (!string.IsNullOrEmpty(search.銀行名稱))
                客戶銀行資訊 = 客戶銀行資訊.Where(x => x.銀行名稱.Contains(search.銀行名稱));
            ViewBag.SearchModel = search;
            return View(客戶銀行資訊.ToList());
        }

        // GET: CustomerBankManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = 客戶銀行資訊Repo.Find(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: CustomerBankManager/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(客戶資料Repo.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: CustomerBankManager/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                客戶銀行資訊Repo.Add(客戶銀行資訊);
                客戶銀行資訊Repo.UnitOfWork.Commit() ;
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(客戶資料Repo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: CustomerBankManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = 客戶銀行資訊Repo.Find(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(客戶資料Repo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: CustomerBankManager/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,FormCollection form)
        {
            var 客戶銀行資訊 = 客戶銀行資訊Repo.Find(id);
            if (TryUpdateModel(客戶銀行資訊))
            {

                客戶銀行資訊Repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(客戶資料Repo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: CustomerBankManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = 客戶銀行資訊Repo.Find(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // POST: CustomerBankManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶銀行資訊 客戶銀行資訊 = 客戶銀行資訊Repo.Find(id);
            客戶銀行資訊Repo.Delete(客戶銀行資訊);
            客戶銀行資訊Repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
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
