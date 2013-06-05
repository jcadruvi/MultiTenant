using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generic.Helpers
{
    public class LayoutHelper
    {
        public static string GetLayout()
        {
            // Default to the generic layout 
            // Note the output will be in the tmp folder when published. 
            string layoutName = "~/tmp/Views/Shared/_Layout.cshtml";
            // If condition is met, use a different layout. 
            if (1 == 1) // NOTE: Condition will be met. 
            {
                layoutName ="~/Views/Shared/_ClientLayoutPage.cshtml";
            }
            return layoutName;
        }
    }
}