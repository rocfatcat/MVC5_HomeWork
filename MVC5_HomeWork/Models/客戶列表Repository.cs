using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5_HomeWork.Models
{   
	public  class 客戶列表Repository : EFRepository<客戶列表>, I客戶列表Repository
	{

    }

	public  interface I客戶列表Repository : IRepository<客戶列表>
	{

	}
}