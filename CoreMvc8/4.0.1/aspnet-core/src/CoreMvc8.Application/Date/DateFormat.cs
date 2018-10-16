using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMvc8.Date
{
    public class DateFormat: IsoDateTimeConverter
    {
        public DateFormat()
        {
            base.DateTimeFormat = "yyyy-MM-dd HH:MM:ss";
        }
    }
}
