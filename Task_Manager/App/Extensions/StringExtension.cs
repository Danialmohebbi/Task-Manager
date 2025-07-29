using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.App.Extensions
{
    public static class StringExtension
    {
        public static string MyHash(this string str)
        {
            int h = 0;
            foreach (char c in str)
            {
                h = (256 * h) + c;
            }
            return (h % (2^32)).ToString();

        }
    }
}
