using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Employee
    {
        private string _name;
        private string _client;
        private int _id;
        private List<string> _clients;
        private static List<Stylists> _stylists = new List<Stylists>();

        public Employee(string name)
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

        public static List<Stylists> GetAllStylists()
        {

        }

        public void Delete()
        {
            
        }

    }
}
