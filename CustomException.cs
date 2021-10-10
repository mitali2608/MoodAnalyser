using System;
using System.Collections.Generic;
using System.Text;

namespace Day20_MoodAnalyser
{
    public class CustomException:Exception
    {
        public enum ExceptionType
        {
            Entered_null,
            Entered_Empty_String,
            No_Such_Class,
            No_Such_Method,
            No_Such_Field
        }

        ExceptionType enumtype;

        public CustomException(ExceptionType type, string msg) : base(msg)
        {
            this.enumtype = type;
        }
    }
}
