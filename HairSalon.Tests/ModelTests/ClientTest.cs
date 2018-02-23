using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTest : IDisposable
    {
        public void Dispose()
        {
            Client.DeleteAll();
            Stylist.DeleteAll();
        }

        public ClientTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=ernest_bruno_test;";
        }

        // First test: Save fails. No method yet.
        [TestMethod]
        public void Save_SavesToDatabase()
        {
            Stylist newStylist = new Stylist("Lily");
            newStylist.Save();
            Client newClient = new Client("Lenon", 1);
            newClient.Save();
            Assert.AreEqual(1, newStylist.GetAllClients().Count);
        }
    }
}
