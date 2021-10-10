using System;
using System.Collections.Generic;
using System.Text;

namespace Day20_MoodAnalyser
{
    public class MoodAnalyserClass
    {
        public string message;
        public MoodAnalyserClass()
        {

        }
        public MoodAnalyserClass(string msg)
        {
            this.message = msg;
        }

        public string AnalyseMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new CustomException(CustomException.ExceptionType.Entered_Empty_String, "String is Empty");
                }

                if (this.message.Contains("Sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.Entered_null, "Nothing is entered");
            }
        }

    }
}
