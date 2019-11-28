using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Api.ServiceModel.DataAnnotations
{
    /// <summary>
    /// 
    /// </summary>
    public class GuidTypeAttribute : ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override string FormatErrorMessage(string name)
        {
            if (!string.IsNullOrEmpty(base.ErrorMessage) || !string.IsNullOrEmpty(base.ErrorMessageResourceName))
            {
                return base.FormatErrorMessage(name);
            }
            return string.Format("error001 : parmater[{0}] is fault.", name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            string text = value.ToString();
            bool flag = Regex.IsMatch(text, @"^[a-zA-Z]\w{2,5}$");
            return flag;
        }
    }
}
