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
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}