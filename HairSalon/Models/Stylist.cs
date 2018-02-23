using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Stylist
    {
        private string _name;
        private string _client;
        private int _id;
        private List<string> _clients;

        public Stylist(string name)
        {
            _name = name;
            _clients = new List<string>();
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public void Save()
        {

        }

        public static List<Stylist> GetAllStylists()
        {
            List<Stylist> myStylists = new List<Stylist>;

            return myStylists;
        }

        public static void DeleteAll()
        {

        }

        public void Delete()
        {

        }

    }
}
