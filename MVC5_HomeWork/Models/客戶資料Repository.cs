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

        public IQueryable<客戶資料> Get客戶資料(客戶資料搜尋ViewModel search_model = null)
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
            return data;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}