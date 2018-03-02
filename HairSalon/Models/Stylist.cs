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
        private string _phonenumber;

        public Stylist(string name, string number)
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

        public void UpdateName(string newName)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE stylists SET name = @newName WHERE id = @id;";

            MySqlParameter name = new MySqlParameter("@newName", newName);
            MySqlParameter id = new MySqlParameter("@id", _id);
            cmd.Parameters.Add(name);
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        public void AddClient(Client newClient)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO client_stylist (client_id, stylist_id) VALUES (@ClientId, @StylistId);";
            MySqlParameter client_id = new MySqlParameter("@ClientId", newClient.GetId());
            MySqlParameter stylist_id = new MySqlParameter("@StylistId", _id);
            cmd.Parameters.Add(client_id);
            cmd.Parameters.Add(stylist_id);
            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        public void AddSpecialty(Specialty newSpecialty)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialty_stylist (specialty_id, stylist_id) VALUES (@SpecialtyId, @StylistId);";
            MySqlParameter specialty_id = new MySqlParameter("@SpecialtyId", newSpecialty.GetId());
            MySqlParameter stylist_id = new MySqlParameter("@StylistId", _id);
            cmd.Parameters.Add(specialty_id);
            cmd.Parameters.Add(stylist_id);
            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        public string GetSpecialty()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT specialties.* FROM specialty_stylist JOIN stylists ON (stylists.id = specialty_stylist.stylist_id) JOIN specialties ON (specialties.id = specialty_stylist.specialty_id) WHERE stylists.id = @StylistId;";

            MySqlParameter stylistId = new MySqlParameter("@StylistId", _id);
            cmd.Parameters.Add(stylistId);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int id = 0;
            string specialty = "";
            while (rdr.Read())
            {
                id = rdr.GetInt32(0);
                specialty = rdr.GetString(1);
            }
            Specialty mySpecialty = new Specialty(specialty);
            mySpecialty.SetId(id);
            conn.Dispose();
            return mySpecialty.GetSpecialty();

        }

        public List<Client> GetAllClients()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM client_stylist WHERE stylist_id = @stylist_id;";

            MySqlParameter tempSID = new MySqlParameter("@stylist_id", _id);
            cmd.Parameters.Add(tempSID);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<int> clientIds = new List<int>();

            while (rdr.Read())
            {
                int clientId = rdr.GetInt32(1);
                clientIds.Add(clientId);
            }
            rdr.Dispose();

            List<Client> clients = new List<Client>{};
            foreach (int clientId in clientIds)
            {
                var clientQuery = conn.CreateCommand() as MySqlCommand;
                clientQuery.CommandText = @"SELECT * FROM clients WHERE id = @ClientId;";

                MySqlParameter clientIdParameter = new MySqlParameter("@ClientId", clientId);
                clientQuery.Parameters.Add(clientIdParameter);

                var rdr2 = clientQuery.ExecuteReader() as MySqlDataReader;
                while (rdr2.Read())
                {
                    int thisClientId = rdr2.GetInt32(0);
                    string clientName = rdr2.GetString(1);
                    string number = rdr2.GetString(2);
                    Client newClient = new Client(clientName, number);
                    newClient.SetId(thisClientId);
                    clients.Add(newClient);

                }
                rdr2.Dispose();
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
            cmd.CommandText = @"INSERT INTO stylists(name, number) VALUES (@name, @number);";

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
            string tempNumber = "";

            while (rdr.Read())
            {
                tempId = rdr.GetInt32(0);
                tempName = rdr.GetString(1);
                tempNumber = rdr.GetString(2);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            Stylist thisStylist = new Stylist(tempName, tempNumber);
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
                string number = rdr.GetString(2);
                Stylist newStylist = new Stylist(name, number);
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
            cmd.CommandText = @"DELETE FROM stylists WHERE id=@id; @DELETE FROM client_stylist WHERE id=@id;";
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
        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }
    }
}
