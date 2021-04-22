using Assignment8;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestProject
{
    public class Tests
    {
        //Create Object of Program Class
        private Program prgObj;
        [SetUp]
        public void Setup()
        {
            prgObj = new Program();
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------Fluent Assertion -------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------
        
        //Age Greater than 20
        [Test]
        public void GetUserInfo_ForAgeGreaterThan20()
        {
            //Act
            var result = prgObj.GetUserInfo();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(5)
                .And.Exactly(4).Property("Age").GreaterThan(20));
        }

        //Age less than 20
        [Test]
        public void GetUserInfo_ForAgeLessThan20()
        {
            //Act
            var result = prgObj.GetUserInfo();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(5)
                .And.Exactly(1).Property("Age").LessThan(20));
        }

        [Test]
        public void GetUserInfo_AgeGreaterThan20_AddressIsBahrain()
        {
            //Act
            var result = prgObj.GetUserInfo();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(5)
                .And.Exactly(4).Property("Age").GreaterThan(20)
                .And.Exactly(1).Property("Address").EqualTo("Bahrain")); ;
        }

        [Test]
        public void GetUserInfo_NameAndAddressTest()
        {
            //Act
            var result = prgObj.GetUserInfo();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(5)
                .And.Exactly(1).Property("Name").EqualTo("Prijitha Ezhava")
                .And.Exactly(2).Property("Address").EqualTo("Ahmedabad"));
        }

        [Test]
        public void GetUserInfo_NameAgeAndAddressTest()
        {
            //Act
            var result = prgObj.GetUserInfo();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(5)
                .And.Exactly(1).Property("Name").EqualTo("Prijith Ezhava")
                .And.Exactly(1).Property("Age").EqualTo(28)
                .And.Exactly(1).Property("Address").EqualTo("Bahrain"));
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------Serial Order of Execution-------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------

        [TearDown]
        public void CleanUpAfterTest()
        {
           // REngineExecutionContext.ClearLog();
        }

        [OrderedTest(0)]
        public void Test1() { }

        [OrderedTest(1)]
        public void Test2() { }

        [OrderedTest(2)]
        public void Test3() { }

       [TestCaseSource(sourceName:"TestSource")]
       public void MainTest(TestStructure test)
        {
            test.Test();
        }

        public static IEnumerable<TestCaseData> TestSource
        {
            get{
                var assembly = Assembly.GetExecutingAssembly();
                Dictionary<int, List<MethodInfo>> methods = (Dictionary<int, List<MethodInfo>>)assembly
                    .GetTypes()
                    .SelectMany(x => x.GetMethods())
                    .Where(y => y.GetCustomAttributes().OfType<OrderedTestAttribute>().Any())
                    .GroupBy(z => z.GetCustomAttribute<OrderedTestAttribute>().Order)
                    .ToDictionary(dict => dict.Key, dict => dict.ToList());

                foreach(var order in methods.Keys.OrderBy(x => x))
                {
                    foreach(var methodInfo in methods[order])
                    {
                        MethodInfo info = methodInfo;
                        yield return new TestCaseData(
                            new TestStructure
                            {
                                Test = () =>
                                {
                                    object classInstance = Activator.CreateInstance(info.DeclaringType, null);
                                    info.Invoke(classInstance, null);
                                }
                            }).SetName(methodInfo.Name);
                    }
                }
            }
        }


    }
}