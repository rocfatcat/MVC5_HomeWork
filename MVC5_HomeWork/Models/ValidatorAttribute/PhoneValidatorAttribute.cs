using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MVC5_HomeWork.Models.ValidatorAttribute
{
    public class PhoneValidatorAttribute : DataTypeAttribute
    {
        private static Regex _regex = new Regex(@"\d{4}-\d{6}");
        public PhoneValidatorAttribute() : base(DataType.PhoneNumber)
        {
            ErrorMessage = "電話格式須為0911-111111";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            string value_string = value as string;
            return value_string != null && _regex.Match(value_string).Success;
        }
    }
}