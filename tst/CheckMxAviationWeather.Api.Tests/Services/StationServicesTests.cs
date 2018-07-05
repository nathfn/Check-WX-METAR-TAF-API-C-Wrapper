using System;
using System.Collections.Generic;
using CheckMxAviationWeather.Api.Enum;
using CheckMxAviationWeather.Api.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckMxAviationWeather.Api.Tests.Services
{
    [TestClass]
    public class StationServicesTests
    {
        [TestMethod]
        public void TestException()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey() + "MONKEY"); // Making the API key wrong on purpose
            try
            {
                service.Stations.Single("EKAH");
                Assert.Fail("API key was accepted even though it was fake!");
            }
            catch (ApiException ei)
            {
                Assert.AreEqual(401, ei.HttpStatusCode);
            }
            catch (Exception)
            {
                Assert.Fail("API key was accepted even though it was fake!");
            }
        }

        [TestMethod]
        public void TestSingle()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var icao = "EKAH";

            var test = service.Stations.Single(icao);

            Assert.AreEqual(icao, test.Icao);

            test = service.Stations.Single("ekah");

            Assert.AreEqual(icao, test.Icao);

            try
            {
                service.Stations.Single("");
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
        public void TestMultiple()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var icaoList = new List<string>
            {
                "EKAH",
                "EKRD",
                "EKYT"
            };

            var test = service.Stations.Multiple(icaoList);

            Assert.AreEqual(3, test.Count);

            try
            {
                service.Stations.Multiple(new List<string>());
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
        public void TestRadius()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var icao = "EKAH";

            var test = service.Stations.Radius(icao, 1);

            Assert.AreEqual(0, test.Count);

            test = service.Stations.Radius(icao, 25);

            Assert.AreEqual(1, test.Count);

            test = service.Stations.Radius(icao, 25, StationType.Heliport);

            Assert.AreEqual(1, test.Count); // This does not work. Type filtering that is!

            test = service.Stations.Radius(icao, 25, StationType.Airport);

            Assert.AreEqual(1, test.Count);

            try
            {
                service.Stations.Radius("", 0);
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
        public void TestLatLon()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var test = service.Stations.LatitudeLongitude(56.347968, 10.582718);

            Assert.AreEqual("EKAH", test.Icao);

        }

        [TestMethod]
        public void TestLatLonRadius()
        {
            var service = new CheckWxServices(TestSetup.GetTestApiKey());

            var test = service.Stations.LatitudeLongitudeRadius(56.347968, 10.582718, 5);

            Assert.AreEqual(1, test.Count);

            test = service.Stations.LatitudeLongitudeRadius(56.347968, 10.582718, 25);

            Assert.AreEqual(3, test.Count);

        }
    }
}
