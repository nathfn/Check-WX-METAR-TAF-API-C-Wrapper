using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckMxAviationWeather.Api.Tests.Services
{
    [TestClass]
    public class MetarServicesTest
    {
        [TestMethod]
        public void TestSingleRaw()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var icao = "EKAH";

            var test = service.Metars.SingleRaw(icao);

            Assert.AreNotEqual(string.Empty, test);

            test = service.Metars.SingleRaw("ekah");

            Assert.AreNotEqual(string.Empty, test);

            try
            {
                service.Metars.SingleRaw("");
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

            var test = service.Metars.MultipleRaw(icaoList);

            Assert.AreEqual(3, test.Count);

            try
            {
                service.Metars.MultipleRaw(new List<string>());
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
        public void TestRadiusRaw()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var icao = "EKAH";

            var test = service.Metars.RadiusRaw(icao, 1);

            Assert.AreEqual(0, test.Count);

            test = service.Metars.RadiusRaw(icao, 60);

            Assert.AreEqual(2, test.Count);

            test = service.Metars.RadiusRaw(icao, 60, true);

            Assert.AreEqual(3, test.Count);

            try
            {
                service.Metars.RadiusRaw("", 0);
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
        public void TestLatLonRaw()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var test = service.Metars.LatitudeLongitudeRaw(56.347968, 10.582718);

            Assert.AreNotEqual(string.Empty, test);

        }

        [TestMethod]
        public void TestSingleDecoded()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var icao = "EKAH";

            var test = service.Metars.SingleDecoded(icao);

            Assert.AreEqual(icao, test.Icao);

            test = service.Metars.SingleDecoded("ekah");

            Assert.AreEqual(icao, test.Icao);

            try
            {
                service.Metars.SingleDecoded("");
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

            var test = service.Metars.MultipleDecoded(icaoList);

            Assert.AreEqual(3, test.Count);

            try
            {
                service.Metars.MultipleDecoded(new List<string>());
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
        public void TestRadiusDecoded()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var icao = "EKAH";

            var test = service.Metars.RadiusDecoded(icao, 1);

            Assert.AreEqual(0, test.Count);

            test = service.Metars.RadiusDecoded(icao, 60);

            Assert.AreEqual(2, test.Count);

            test = service.Metars.RadiusDecoded(icao, 60, true);

            Assert.AreEqual(3, test.Count);

            try
            {
                service.Metars.RadiusDecoded("", 0);
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
        public void TestLatLonDecoded()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var test = service.Metars.LatitudeLongitudeDecoded(56.347968, 10.582718);

            Assert.AreEqual("EKAH", test.Icao);

        }
    }
}
