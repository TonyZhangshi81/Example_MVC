using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Example.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class ExtBooleanConverter : System.ComponentModel.BooleanConverter
    {
        private readonly HashSet<string> _trueStrings = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private readonly HashSet<string> _falseStrings = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// 
        /// </summary>
        public ExtBooleanConverter()
        {
            _trueStrings.Add(bool.TrueString);
            _trueStrings.Add("1");
            _trueStrings.Add("-1");
            _trueStrings.Add("Y");
            _trueStrings.Add("y");
            _falseStrings.Add(bool.FalseString);
            _falseStrings.Add("0");
            _falseStrings.Add("N");
            _falseStrings.Add("n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                if (value == null)
                {
                    return false;
                }
                if (_trueStrings.Contains(value.ToString()))
                {
                    return true;
                }
                if (_falseStrings.Contains(value.ToString()))
                {
                    return false;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is bool && destinationType == typeof(string))
            {
                if ((bool)value)
                {
                    return "1";
                }
                return "0";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
