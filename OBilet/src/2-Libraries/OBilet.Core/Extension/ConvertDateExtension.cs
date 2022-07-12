using System.Globalization;

namespace OBilet.Core.Extension
{
    public static class ConvertDateExtension
    {
        public static DateTime ConvertDt(this string DepartureDate)
        {

            DateTimeFormatInfo usDtfi = new CultureInfo("en-US", false).DateTimeFormat;
            DateTimeFormatInfo trDtfi = new CultureInfo("tr-TR", false).DateTimeFormat;
            string usFormat = Convert.ToDateTime(Convert.ToDateTime(DepartureDate, trDtfi)).ToString(usDtfi);
            DateTime newFormat = Convert.ToDateTime(usFormat);
            return newFormat;
        }
    }
}
