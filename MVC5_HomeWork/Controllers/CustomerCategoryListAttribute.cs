using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC5_HomeWork.Controllers
{
    public class CustomerCategoryListAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "優良", Value = "優良" });
            items.Add(new SelectListItem() { Text = "標準", Value = "標準" });
            items.Add(new SelectListItem() { Text = "惡劣", Value = "惡劣" });

            //filterContext.Controller.ViewBag.客戶分類 = new SelectList(items, "Value", "Text");
            filterContext.Controller.ViewBag.客戶分類 = new SelectList(items, "Value", "Text");
            base.OnActionExecuting(filterContext);
        }
    }
}