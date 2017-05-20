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
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}