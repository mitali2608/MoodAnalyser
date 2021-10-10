using Day20_MoodAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {//Arrange
            string msg = "I am in Sad Mood";
            MoodAnalyserClass mood = new MoodAnalyserClass(msg);
            //Act
            string result = mood.AnalyseMood();
            //Assert
            Assert.AreEqual("SAD", result);
        }

        //TC 1.2
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            string msg = "I am in Happy Mood";
            MoodAnalyserClass mood = new MoodAnalyserClass(msg);
            //Act
            string result = mood.AnalyseMood();
            //Assert
            Assert.AreEqual("HAPPY", result);

        }

        //Tc 2.1
        [TestMethod]

        public void TestMethod3()
        {
            MoodAnalyserClass mood = new MoodAnalyserClass("null");
            string result = mood.AnalyseMood();
            Assert.AreEqual("HAPPY", result);
        }

        //TC 3.1
        [TestMethod]

        public void TestMethod4()
        {
            try
            {
                //Arrange
                string message = "I am in happy mood";
                MoodAnalyserClass mood = new MoodAnalyserClass(message);
                //Act
                string result = mood.AnalyseMood();
                //Assert
                Assert.AreEqual("HAPPY", result);
            }
            catch (CustomException custom)
            {
                Assert.AreEqual("Nothing is entered", custom.Message);
            }
        }

        //TC 3.2
        [TestMethod]
        public void TestMethod5()
        {
            try
            {
                string message = "";
                MoodAnalyserClass mood = new MoodAnalyserClass(message);
                string result = mood.AnalyseMood();
            }
            catch (CustomException custom)
            {
                Assert.AreEqual("String is Empty", custom.Message);
            }
        }

        //TC 4.1
        [TestMethod]
        public void TestMethod6()
        {
            string message = null;
            object expected = new MoodAnalyserClass(message);
            object obj = Reflections.CreatMoodAnalyser("MSTestMoodAnalyserDay20.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }

        //TC 4.2
        [TestMethod]
        public void TestMethod7()
        {
            string msg = "Class not found";
            try
            {
                object obj = Reflections.CreatMoodAnalyser("MSTestMoodAnalyserDay20.MoodAnalyserFake", "MoodAnalyserFake");
            }
            catch (CustomException custom)
            {
                Assert.AreEqual(msg, custom.Message);
            }
        }

        //TC 4.3
        [TestMethod]
        public void TestMethod8()
        {
            string msg = "Constructor is not found";
            try
            {
                object obj = Reflections.CreatMoodAnalyser("MSTestMoodAnalyserDay20.MoodAnalyser", "MoodAnalyserFake");
            }
            catch (CustomException custom)
            {
                Assert.AreEqual(msg, custom.Message);
            }
        }

        //TC 5.1
        [TestMethod]
        public void TestMethod9()
        {
            object expected = new MoodAnalyserClass("HAPPY");
            object obj = Reflections.CreateMoodAnalyseUsingParameterizedConstructor("MSTestMoodAnalyserDay20.MoodAnalyser", "MoodAnalyser", "HAPPY");
            expected.Equals(obj);
        }

        //TC 5.2
        [TestMethod]
        public void TestMethod10()
        {
            string msg = "Class not found";
            try
            {
                object obj = Reflections.CreateMoodAnalyseUsingParameterizedConstructor("MSTestMoodAnalyserDay20.MoodAnalyserFake", "MoodAnalyserFake", "HAPPY");
            }
            catch (CustomException custom)
            {
                Assert.AreEqual(msg, custom.Message);
            }
        }

        //TC 5.3
        [TestMethod]
        public void TestMethod11()
        {
            string msg = "Constructor is not found";
            try
            {
                object obj = Reflections.CreateMoodAnalyseUsingParameterizedConstructor("MSTestMoodAnalyserDay20.MoodAnalyser", "MoodAnalyserFake", "HAPPY");
            }
            catch (CustomException custom)
            {
                Assert.AreEqual(msg, custom.Message);
            }
        }

        //TC 6.1
        [TestMethod]
        public void TestMethod12()
        {
            string expected = "HAPPY";
            string mood = Reflections.InvokeAnalyseMethod("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }

        //TC 6.2
        [TestMethod]
        public void TestMethod13()
        {
            string expected = "No such method exists";
            try
            {
                string mood = Reflections.InvokeAnalyseMethod("Happy", "AnalyseMoodFake");
            }
            catch (CustomException custom)
            {
                Assert.AreEqual(expected, custom.Message);
            }
        }

        //TC 7.1
        [TestMethod]
        public void TestMethod14()
        {
            string result = Reflections.setField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }

        //TC 7.2
        [TestMethod]
        public void TestMethod15()
        {
            string expected = "field is not found";
            try
            {
                string result = Reflections.setField("HAPPY", "messageFake");
            }
            catch (CustomException custom)
            {
                Assert.AreEqual(expected, custom.Message);
            }
        }

        //TC 7.3
        [TestMethod]
        public void TestMethod16()
        {
            string expected = "Message should not be null";
            try
            {
                string result = Reflections.setField(null, "message");
            }
            catch (CustomException custom)
            {
                Assert.AreEqual(expected, custom.Message);
            }
        }
    }
}
