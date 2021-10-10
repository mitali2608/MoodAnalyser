using Day20_MoodAnalyser;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Day20_MoodAnalyser
{
    public class Reflections
    {
        // UC 4 
        public static object CreatMoodAnalyser(string classname, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(classname, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalysetype = executing.GetType(classname);
                    return Activator.CreateInstance(moodAnalysetype);
                }
                catch (ArgumentNullException)
                {
                    throw new CustomException(CustomException.ExceptionType.No_Such_Class, "Class not found");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.No_Such_Method, "Constructor is not found");
            }
        }

        //UC 5

        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyserClass);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new CustomException(CustomException.ExceptionType.No_Such_Method, "Constructor is not found");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.No_Such_Class, "Class not found");
            }
        }

        //UC 6

        public static string InvokeAnalyseMethod(string msg, string methodName)
        {
            try
            {
                Type type = Type.GetType("MSTestMoodAnalyserDay20.MoodAnalyser");
                object moodAnalyserObject = Reflections.CreateMoodAnalyseUsingParameterizedConstructor("MSTestMoodAnalyserDay20.MoodAnalyser",
                    "MoodAnalyser", msg);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyserObject, null);
                return mood.ToString();

            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.No_Such_Method, "No such method exists");
            }
        }


        //UC 7

        public static string setField(string message, string fieldName)
        {
            try
            {
                MoodAnalyserClass mood = new MoodAnalyserClass();
                Type type = typeof(MoodAnalyserClass);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new CustomException(CustomException.ExceptionType.No_Such_Field, "Message should not be null");
                }
                field.SetValue(mood, message);
                return mood.message;
            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.No_Such_Field, "field is not found");
            }
        }
    }
}