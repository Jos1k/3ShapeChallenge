using Newtonsoft.Json.Converters;
using System.Globalization;

namespace _3ShapeChallenge.Misc
{
    public class StrictDateConverter: IsoDateTimeConverter
    {
        public StrictDateConverter()
        {
            DateTimeFormat = "dd-MM-yyyy";
            Culture = CultureInfo.InvariantCulture;
            DateTimeStyles = DateTimeStyles.AssumeUniversal;
        }
    }
}
