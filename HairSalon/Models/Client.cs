using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Client
    {
        private string _name;
        private int _id;
        private string _phonenumber;
        private int _stylistId;

        public Client(string name, string number, int stylistId)
        {
            _name = name;
            _phonenumber = number;
            _stylistId = stylistId;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetPhoneNumber()
        {
            return _phonenumber;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public int GetStylistId()
        {
            return _stylistId;
        }

        public static Client Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id=@id;";
            cmd.Parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int tempId =0;
            string tempName = "";
            string tempNumber = "";
            int tempStylistId = 0;

            while (rdr.Read())
            {
                tempId = rdr.GetInt32(0);
                tempName = rdr.GetString(1);
                tempNumber = rdr.GetString(2);
                tempStylistId = rdr.GetInt32(3);
            }

            Client thisClient = new Client(tempName, tempNumber, tempStylistId);
            thisClient.SetId(tempId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return thisClient;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (name, number, stylist_id) VALUES (@name, @number, @stylist_id);";

            MySqlParameter name = new MySqlParameter("@name", _name);
            MySqlParameter number = new MySqlParameter("@number", _phonenumber);
            MySqlParameter stylist = new MySqlParameter("@stylist_id", _stylistId);
            cmd.Parameters.Add(name);
            cmd.Parameters.Add(number);
            cmd.Parameters.Add(stylist);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;";
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
            cmd.CommandText = @"DELETE FROM clients WHERE id=@id;";
            MySqlParameter tempId = new MySqlParameter("@id", _id);
            cmd.Parameters.Add(tempId);
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                return (newClient.GetName() == _name);
            }
        }
    }
}
