using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringValidation
{
    public class StringVerification
    {
        
        public bool StringVerif(string text){
            var regex = @"^[a-zA-Z0-9]{5,15}$";
            var match = Regex.Match(text, regex, RegexOptions.IgnoreCase);
            if (match.Success)
                return true;
            else
                return false;
        }

    }
}
