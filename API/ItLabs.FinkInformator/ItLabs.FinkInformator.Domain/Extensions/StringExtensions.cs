using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLabs.FinkInformator.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string ToUpperCaseCustom(this string input)
        {
            return input.ToUpper();
        }
    }
}
