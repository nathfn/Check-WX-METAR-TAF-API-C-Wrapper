using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckMxAviationWeather.Api.Tests.Services
{
    [TestClass]
    public class TafServicesTest
    {
        [TestMethod]
        public void TestSingleRaw()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var icao = "EKAH";

            var test = service.Tafs.SingleRaw(icao);

            Assert.AreNotEqual(string.Empty, test);

            test = service.Tafs.SingleRaw("ekah");

            Assert.AreNotEqual(string.Empty, test);

            try
            {
                service.Tafs.SingleRaw("");
                Assert.Fail("Empty ICAO must throw exception!");
            }
            catch (ArgumentNullException)
            {
                // Expected!
            }
            catch (Exception)
            {
                Assert.Fail("Empty ICAO must throw argument null exception!");
            }
        }

        [TestMethod]
        public void TestMultipleRaw()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var icaoList = new List<string>
            {
                "EKAH",
                "EKRD",
                "EKYT"
            };

            var test = service.Tafs.MultipleRaw(icaoList);

            Assert.AreEqual(3, test.Count);

            try
            {
                service.Tafs.MultipleRaw(new List<string>());
                Assert.Fail("Empty ICAO list must throw exception!");
            }
            catch (ArgumentException)
            {
                // Expected!
            }
            catch (Exception)
            {
                Assert.Fail("Empty ICAO list must throw argument exception!");
            }
        }

        

        [TestMethod]
        public void TestSingleDecoded()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var icao = "EKAH";

            var test = service.Tafs.SingleDecoded(icao);

            Assert.AreEqual(icao, test.Icao);

            test = service.Tafs.SingleDecoded("ekah");

            Assert.AreEqual(icao, test.Icao);

            try
            {
                service.Tafs.SingleDecoded("");
                Assert.Fail("Empty ICAO must throw exception!");
            }
            catch (ArgumentNullException)
            {
                // Expected!
            }
            catch (Exception)
            {
                Assert.Fail("Empty ICAO must throw argument null exception!");
            }
        }

        [TestMethod]
        public void TestMultipleDecoded()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var icaoList = new List<string>
            {
                "EKAH",
                "EKRD",
                "EKYT"
            };

            var test = service.Tafs.MultipleDecoded(icaoList);

            Assert.AreEqual(3, test.Count);

            try
            {
                service.Tafs.MultipleDecoded(new List<string>());
                Assert.Fail("Empty ICAO list must throw exception!");
            }
            catch (ArgumentException)
            {
                // Expected!
            }
            catch (Exception)
            {
                Assert.Fail("Empty ICAO list must throw argument exception!");
            }
        }
        
    }
}
