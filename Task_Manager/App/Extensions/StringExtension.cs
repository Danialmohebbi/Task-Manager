using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.App.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Generate a simple hash value from a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns>A string representation of the computed hash as an unassigned 32-bit integer.</returns>
        public static string MyHash(this string str)
        {
            int h = 0;
            foreach (char c in str)
            {
                h = (256 * h) + c;
            }
            return ((uint) h).ToString();

        }
    }
}
