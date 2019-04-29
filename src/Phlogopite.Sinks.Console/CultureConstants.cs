using System.Globalization;

namespace Phlogopite
{
    internal static class CultureConstants
    {
        private static CultureInfo s_fixedCulture;

        internal static CultureInfo FixedCulture => s_fixedCulture ?? (s_fixedCulture = CreateFixedCulture());

        private static CultureInfo CreateFixedCulture()
        {
            var result = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            result.DateTimeFormat = CreateFixedDateTimeFormat();
            return result;
        }

        private static DateTimeFormatInfo CreateFixedDateTimeFormat()
        {
            var result = (DateTimeFormatInfo)CultureInfo.InvariantCulture.DateTimeFormat.Clone();
            result.ShortDatePattern = "yyyy-MM-dd";
            return result;
        }
    }
}
