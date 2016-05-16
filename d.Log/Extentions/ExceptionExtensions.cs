using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace d.Log.Extentions
{
    public static  class ExceptionExtensions
    {
        public static string ToStringEx(this Exception ex)
        {
            List<object> fullData = new List<object>();
            fullData.Add(ex);
            if (ex.InnerException != null)
                fullData.Add(ex.InnerException);

            return string.Join(" ", fullData.Select(e => e == null ? string.Empty : e.ToString()).ToArray());
        }
    }
}
