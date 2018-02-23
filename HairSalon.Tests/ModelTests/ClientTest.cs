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
        // Second test: Pass.
        [TestMethod]
        public void Save_SavesToDatabase()
        {
            Stylist newStylist = new Stylist("Lily", "(111) 222-3333");
            newStylist.Save();
            Client newClient = new Client("Lenon", "(444) 555-6666", 1);
            newClient.Save();
            Assert.AreEqual(1, newStylist.GetAllClients().Count);
        }

        [TestMethod]
        public void Save_SavesToCorrectStylist()
        {
            Stylist newStylist = new Stylist("Lita", "(555) 333-444");
            newStylist.Save();
            Client newClient = new Client("Lyra", "(111) 222-3333", 1);
            newClient.Save();
            Client newClient2 = new Client("Lola", "(444) 555-6666", 1);
            newClient.Save();
            Assert.AreEqual(2, newStylist.GetAllClients().Count);
        }

        [TestMethod]
        public void Find_FindCorrectClient()
        {
            Client newClient = new Client("Bob", "(111) 222-3333", 1);
            newClient.Save();
            Assert.AreEqual(newClient, Client.Find(newClient.GetId()));
        }
    }
}
