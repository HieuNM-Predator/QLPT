using System.Text.RegularExpressions;

namespace QLPT_API.Helper
{
    public class InputHelper
    {
        public static bool IsEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        public static bool IsDateTime(string dt)
        {
            string format = "yyyy/MM/dd";
            DateTime resultDateTime;
            bool result = DateTime.TryParseExact(dt, format, null, System.Globalization.DateTimeStyles.None, out resultDateTime);
            return result;
        }
    }
}
