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
    public class CustomerBankContactManageController : Controller
    {
        //private 客戶資料Entities db = new 客戶資料Entities();
        客戶聯絡人Repository 客戶聯絡人repo = RepositoryHelper.Get客戶聯絡人Repository();
        客戶資料Repository 客戶資料repo ;

        public CustomerBankContactManageController()
        {
            客戶資料repo = RepositoryHelper.Get客戶資料Repository(客戶聯絡人repo.UnitOfWork);
        }
        // GET: CustomerBankContactManage
        public ActionResult Index(客戶聯絡人搜尋ViewModel search_model, OrderViewModel order_model , int? 客戶Id)
        {
            var 職稱 = 客戶聯絡人repo.All().Select(x => x.職稱).Distinct();

            var 職稱種類 = new List<SelectListItem>();

            foreach (var item in 職稱)
            {
                職稱種類.Add(new SelectListItem() { Text = item, Value = item });
            }

            ViewBag.職稱種類 = 職稱種類;
            var 客戶聯絡人 = 客戶聯絡人repo.Get客戶聯絡人(search_model:search_model, order_model: order_model);
            return View(客戶聯絡人.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(客戶銀行資訊SearchModel search)
        {
            var 客戶聯絡人 = 客戶聯絡人repo.All().Where(x => x.刪除 != true);
            return View(客戶聯絡人.ToList());
        }
        // GET: CustomerBankContactManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = 客戶聯絡人repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: CustomerBankContactManage/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(客戶聯絡人repo.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: CustomerBankContactManage/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                客戶聯絡人repo.Add(客戶聯絡人);
                客戶聯絡人repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: CustomerBankContactManage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = 客戶聯絡人repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: CustomerBankContactManage/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,FormCollection from)
        {
            客戶聯絡人 客戶聯絡人= 客戶聯絡人repo.Find(id);

            if (TryUpdateModel< 客戶聯絡人>(客戶聯絡人))
            {
                客戶聯絡人repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: CustomerBankContactManage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = 客戶聯絡人repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: CustomerBankContactManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = 客戶聯絡人repo.Find(id);
            客戶聯絡人repo.Delete(客戶聯絡人);
            客戶聯絡人repo.UnitOfWork.Commit();
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
