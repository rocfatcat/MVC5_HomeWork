using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_HomeWork.Models
{
    public class SearchViewModel
    {
        public string ColumnName { get; set; }
        public string SearchText { get; set; }
    }

    public class 客戶銀行資訊SearchModel
    {
        public string 銀行名稱 { get; set; }
        public string 銀行代碼 { get; set; }
        public string 分行代碼 { get; set; }
        public string 帳戶名稱 { get; set; }
        public string 帳戶號碼 { get; set; }
    }

    public class 客戶資料搜尋ViewModel
    {
        public string 客戶類型Type { get; set; }
        public string SearchKeyword { get; set; }
    }
}