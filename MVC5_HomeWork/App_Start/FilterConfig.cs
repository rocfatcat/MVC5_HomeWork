﻿using System.Web;
using System.Web.Mvc;

namespace MVC5_HomeWork
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
