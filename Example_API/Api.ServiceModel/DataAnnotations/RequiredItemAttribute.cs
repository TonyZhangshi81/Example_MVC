using System;
using System.ComponentModel.DataAnnotations;

namespace Api.ServiceModel.DataAnnotations
{
    /// <summary>
    /// 
    /// </summary>
    public class RequiredItemAttribute : RequiredAttribute
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
            return "error : parmater is fault.";
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
                return false;
            }
            string text = value.ToString();
            bool flag = !string.IsNullOrEmpty(text);
            return flag;
        }
    }
}
