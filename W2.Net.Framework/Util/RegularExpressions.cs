using System;
using System.Text.RegularExpressions;

namespace W2.Net.Framework.Util
{
    public class RegularExpressions
    {
        private const string VALID_EMAIL_REGEX = @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$";

        public static bool ValidateEmail(String email)
        {
            return new Regex(VALID_EMAIL_REGEX).IsMatch(email);
        }
    }
}
