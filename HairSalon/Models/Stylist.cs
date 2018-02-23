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
            List<Stylist> myStylists = new List<Stylist>();
            
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Stylist newStylist = new Stylist(name);
                newStylist.SetId(id);
                myStylists.Add(newStylist);
            }

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
