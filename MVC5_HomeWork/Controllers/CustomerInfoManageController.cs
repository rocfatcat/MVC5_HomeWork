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
        [CustomerCategoryList]
        public ActionResult Index(客戶資料搜尋ViewModel search_model)
        {
          
            return View(客戶資料repo.Get客戶資料(search_model));
        }

        // GET: CustomerManage/Details/5
        [CustomerCategoryList]
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
        [CustomerCategoryList]
        public ActionResult Create()
        {

            return View();
        }

        // POST: CustomerManage/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomerCategoryList]
        public ActionResult Create(int id , FormCollection form)
        {
            客戶資料 客戶資料 = 客戶資料repo.Find(id);
            if (TryUpdateModel(客戶資料))
            {
                客戶資料repo.Add(客戶資料);
                客戶資料repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: CustomerManage/Edit/5
        [CustomerCategoryList]
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
        [CustomerCategoryList]
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
        [CustomerCategoryList]
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
