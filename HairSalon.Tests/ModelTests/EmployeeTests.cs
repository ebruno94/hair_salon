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
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=ernest_bruno_test;";
        }

        // Test Passes, nothing in database yet.
        // Fails after running more tests.
        [TestMethod]
        public void GetAll_DatabaseEmptyAtFirst_0()
        {
            Assert.AreEqual(0, Stylist.GetAllStylists().Count);
        }

        // Test Save
        [TestMethod]
        public void Save_SavesToDatabase_List()
        {
            Stylist testStylist = new Stylist("Jamie");
            testStylist.Save();
            List<Stylist> stylists = Stylist.GetAllStylists();
            CollectionAssert.AreEqual(new List<Stylist>{testStylist}, stylists);
        }

        // First test: Delete should fail (No method written yet);
        [TestMethod]
        public void Delete_DeleteStylist()
        {
            Stylist testStylist = new Stylist("James");
            testStylist.Save();
            testStylist.Delete();
            Assert.AreEqual(0, Stylist.GetAllStylists().Count);
        }
    }
}
