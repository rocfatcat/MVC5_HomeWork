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
    public class CustomerInfoManageController : Controller
    {
        private 客戶資料Repository 客戶資料repo =RepositoryHelper.Get客戶資料Repository();

        // GET: CustomerManage
        public ActionResult Index()
        {
            return View(客戶資料repo.All().Where(x => x.刪除 != true));
        }

        // GET: CustomerManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = 客戶資料repo.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: CustomerManage/Create
        public ActionResult Create()
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "優良", Value = "優良" });
            items.Add(new SelectListItem() { Text = "標準", Value = "標準" });
            items.Add(new SelectListItem() { Text = "惡劣", Value = "惡劣" });

            ViewBag.客戶分類 = new SelectList(items, "Value", "Text");
            return View();
        }

        // POST: CustomerManage/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                客戶資料repo.Add(客戶資料);
                客戶資料repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: CustomerManage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = 客戶資料repo.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: CustomerManage/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,FormCollection form)
        {
            var 客戶資料 = 客戶資料repo.Find(id);

            if(客戶資料 == null)
            {
                return HttpNotFound();
            }

            if (TryUpdateModel< 客戶資料>(客戶資料))
            {
                客戶資料repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: CustomerManage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = 客戶資料repo.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: CustomerManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = 客戶資料repo.Find(id);

            客戶資料repo.Delete(客戶資料);
            客戶資料repo.UnitOfWork.Commit();
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
