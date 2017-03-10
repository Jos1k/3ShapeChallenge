using System;
using System.ComponentModel.DataAnnotations;

namespace _3ShapeChallenge.Misc
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StrictDateAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            DateTime result;

            StrictDateConverter dateConverter = new StrictDateConverter();
            return DateTime.TryParseExact(
                value as string,
                dateConverter.DateTimeFormat,
                dateConverter.Culture,
                dateConverter.DateTimeStyles, 
                out result
            );
        }
    }
}
