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

        public Client(string name, string number)
        {
            _name = name;
            _phonenumber = number;
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

        public static Client Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id=@id;";
            cmd.Parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int tempId = 0;
            string tempName = "";
            string tempNumber = "";

            while (rdr.Read())
            {
                tempId = rdr.GetInt32(0);
                tempName = rdr.GetString(1);
                tempNumber = rdr.GetString(2);
            }

            Client thisClient = new Client(tempName, tempNumber);
            thisClient.SetId(tempId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return thisClient;
        }

        public string GetAssignedStylist()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT stylists.* FROM clients JOIN client_stylist ON (clients.id = client_stylist.client_id) JOIN stylists ON (client_stylist.stylist_id = stylists.id) WHERE clients.id = @ClientId;";

            MySqlParameter clientId = new MySqlParameter("@ClientId", _id);
            cmd.Parameters.Add(clientId);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int id = 0;
            string stylistName = "";
            string stylistNumber = "";
            while (rdr.Read())
            {
                id = rdr.GetInt32(0);
                stylistName = rdr.GetString(1);
                stylistNumber = rdr.GetString(2);
            }
            conn.Dispose();
            Stylist myStylist = new Stylist(stylistName, stylistNumber);
            myStylist.SetId(id);
            return myStylist.GetName();
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (name, number) VALUES (@name, @number);";

            MySqlParameter name = new MySqlParameter("@name", _name);
            MySqlParameter number = new MySqlParameter("@number", _phonenumber);
            cmd.Parameters.Add(name);
            cmd.Parameters.Add(number);

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
            cmd.CommandText = @"DELETE FROM clients; DELETE FROM client_stylist";
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
            cmd.CommandText = @"DELETE FROM clients WHERE id=@id; DELETE FROM client_stylist WHERE id=@id";
            MySqlParameter tempId = new MySqlParameter("@id", _id);
            cmd.Parameters.Add(tempId);
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                string clientNumber = rdr.GetString(2);
                Client newClient = new Client(clientName, clientNumber);
                newClient.SetId(clientId);
                allClients.Add(newClient);
            }
            conn.Dispose();
            return allClients;
        }


        public void UpdateInfo(string newName, string newNum)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE clients SET name = @newName, number = @newNum WHERE id = @id;";

            MySqlParameter name = new MySqlParameter("@newName", newName);
            MySqlParameter num = new MySqlParameter("@newNum", newNum);
            MySqlParameter id = new MySqlParameter("@id", _id);
            cmd.Parameters.Add(name);
            cmd.Parameters.Add(num);
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            conn.Dispose();
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

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }
    }
}
