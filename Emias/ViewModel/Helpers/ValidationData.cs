using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Emias.ViewModel.Helpers
{
    public static class ValidationData
    {
        public static bool ValidatePolis(string input)
        {
            if (!string.IsNullOrEmpty(input) && input.All(char.IsDigit))
            {
                return input.Length == 16;
            }
            else
            {
                return false;
            }
        }
        public static bool ValidateAdminID(string input)
        {
            if (!string.IsNullOrEmpty(input) && input.All(char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ValidatePassword(string password)
        {
            string pattern = @"^[a-zA-Z0-9!@#$%^&*()-_=+`~;:'""|\\,<.>/?\[\]{}]*$";
            return Regex.IsMatch(password, pattern);
        }
    }
}
