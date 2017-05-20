using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5_HomeWork.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override void Delete(客戶資料 entity)
        {
            entity.刪除 = true;
        }
        public 客戶資料 Find(int id)
        {
            return this.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<客戶資料> Get客戶資料(客戶資料搜尋ViewModel search_model = null, OrderViewModel order_model = null)
        {
            var data = this.Where(c => c.刪除 == false).AsQueryable();
            if(search_model != null)
            {
                if(!string.IsNullOrEmpty(search_model.客戶類型Type))
                {
                    data = data.Where(c => c.客戶分類 == search_model.客戶類型Type);
                }
                if (!string.IsNullOrEmpty(search_model.SearchKeyword))
                {
                    data = data.Where(c => c.客戶名稱.Contains(search_model.SearchKeyword));
                }
            }

            if(order_model != null && order_model.SortColumn != null && typeof(客戶資料).GetProperty(order_model.SortColumn) != null)
            {
                switch(order_model.SortColumn)
                {
                    case "客戶名稱":
                        if(order_model.Desc == false)
                        {
                            data = data.OrderBy(m => m.客戶名稱);
                        }
                        else
                        {
                            data = data.OrderByDescending(m => m.客戶名稱);
                        }
                        break;
                    case "統一編號":
                        if (order_model.Desc == false)
                        {
                            data = data.OrderBy(m => m.統一編號);
                        }
                        else
                        {
                            data = data.OrderByDescending(m => m.統一編號);
                        }
                        break;
                    case "電話":
                        if (order_model.Desc == false)
                        {
                            data = data.OrderBy(m => m.電話);
                        }
                        else
                        {
                            data = data.OrderByDescending(m => m.電話);
                        }
                        break;
                    case "傳真":
                        if (order_model.Desc == false)
                        {
                            data = data.OrderBy(m => m.傳真);
                        }
                        else
                        {
                            data = data.OrderByDescending(m => m.傳真);
                        }
                        break;
                    case "地址":
                        if (order_model.Desc == false)
                        {
                            data = data.OrderBy(m => m.地址);
                        }
                        else
                        {
                            data = data.OrderByDescending(m => m.地址);
                        }
                        break;
                    case "Email":
                        if (order_model.Desc == false)
                        {
                            data = data.OrderBy(m => m.Email);
                        }
                        else
                        {
                            data = data.OrderByDescending(m => m.Email);
                        }
                        break;

                    case "客戶分類":
                        if (order_model.Desc == false)
                        {
                            data = data.OrderBy(m => m.客戶分類);
                        }
                        else
                        {
                            data = data.OrderByDescending(m => m.客戶分類);
                        }
                        break;
                }                                                                  

            }
            return data;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}