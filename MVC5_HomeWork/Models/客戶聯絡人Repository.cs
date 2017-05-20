using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5_HomeWork.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override void Delete(客戶聯絡人 entity)
        {
            entity.刪除 = true;
        }

        public 客戶聯絡人 Find (int id)
        {
            return this.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<客戶聯絡人> Get客戶聯絡人(客戶聯絡人搜尋ViewModel search_model = null, OrderViewModel order_model = null)
        {
            var data = this.Where(c => c.刪除 == false).AsQueryable();
            if (search_model != null)
            {
                if (!string.IsNullOrEmpty(search_model.職稱Type))
                {
                    data = data.Where(c => c.職稱 == search_model.職稱Type);
                }
            }

            if (order_model != null && order_model.SortColumn != null && typeof(客戶聯絡人).GetProperty(order_model.SortColumn) != null)
            {
                switch (order_model.SortColumn)
                {
                    case "職稱":
                        if (order_model.Desc == false)
                        {
                            data = data.OrderBy(m => m.職稱);
                        }
                        else
                        {
                            data = data.OrderByDescending(m => m.職稱);
                        }
                        break;
                    case "姓名":
                        if (order_model.Desc == false)
                        {
                            data = data.OrderBy(m => m.姓名);
                        }
                        else
                        {
                            data = data.OrderByDescending(m => m.姓名);
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
                    case "手機":
                        if (order_model.Desc == false)
                        {
                            data = data.OrderBy(m => m.手機);
                        }
                        else
                        {
                            data = data.OrderByDescending(m => m.手機);
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

                }

            }
            return data;
        }

    }

    public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}