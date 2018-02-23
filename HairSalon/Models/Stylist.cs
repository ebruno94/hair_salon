using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Stylist
    {
        private string _name;
        private int _id;
        private List<Client> _clients;

        public Stylist(string name)
        {
            _name = name;
            _clients = new List<Client>();
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

        public List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                int stylistId = rdr.GetInt32(2);
                Client tempClient = new Client(name, stylistId);
                tempClient.SetId(id);
                clients.Add(tempClient);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return clients;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists(name) VALUES (@name);";

            MySqlParameter name = new MySqlParameter("@name", _name);
            cmd.Parameters.Add(name);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Stylist Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id=@id;";
            cmd.Parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            string tempName = "";
            int tempId = 0;

            while (rdr.Read())
            {
                tempId = rdr.GetInt32(0);
                tempName = rdr.GetString(1);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            Stylist thisStylist = new Stylist(tempName);
            thisStylist.SetId(tempId);
            return thisStylist;
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

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return myStylists;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists;";
            cmd.ExecuteNonQuery();

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists WHERE id=@id;";
            MySqlParameter tempId = new MySqlParameter("@id", _id);
            cmd.Parameters.Add(tempId);
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                return (newStylist.GetName() == _name);
            }
        }
    }
}
