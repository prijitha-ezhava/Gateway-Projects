using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentLibraryDataAnnotation.Custom_Annotation
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute(string minDateValue) : base(typeof(DateTime), minDateValue, DateTime.Now.ToShortDateString())
        {
        }
    }
}