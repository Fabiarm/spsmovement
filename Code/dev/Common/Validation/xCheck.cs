using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Movement.Common.Validation
{
    public class xCheck
    {
        protected static string argNullMessage = "Argument or parameter has been absent";
        public static void Require(bool assertion, string message)
        {
            if (!assertion) throw new ArgumentNullException(message);
        }
        public static void Require(bool assertion)
        {
            if (!assertion) throw new ArgumentNullException(argNullMessage);
        }
        public static void Require(object value, string message)
        {
            if (value == null)
                throw new ArgumentNullException(message);
        }
        public static void Require(object value)
        {
            if (value == null)
                throw new ArgumentNullException(argNullMessage);
        }
    }
}
