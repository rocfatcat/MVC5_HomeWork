﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_HomeWork.Models.ViewModel
{
    public partial class 客戶列表
    {
        public int Id { get; set; }
        public string 客戶名稱 { get; set; }
        public int 聯絡人數量 { get; set; }
        public int 銀行帳戶數量 { get; set; }
    }

}