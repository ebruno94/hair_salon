using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTest : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        public StylistTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=ernest_bruno_tests;";
        }

        // Test Passes, nothing in database yet.
        [TestMethod]
        public void GetAll_DatabaseEmptyAtFirst_0()
        {
            Assert.AreEqual(0, Stylist.GetAllStylists().Count);
        }
    }
}
