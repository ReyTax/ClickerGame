using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickerGame.Model
{
    public class DBManipulationLogin
    {
        private SQLiteConnection _conn;
        public void ConnectToLoginDB()
        {
            if (!File.Exists("LoginDB.sqlite"))
            {
                SQLiteConnection.CreateFile("LoginDB.sqlite");
            }
            try
            {
                _conn = new SQLiteConnection("DataSource=LoginDB.sqlite;Version=3;");
                _conn.Open();
                string stmt = "CREATE TABLE IF NOT EXISTS Login(id BLOB, username TEXT, parola BLOB)";
                SQLiteCommand cmd = new SQLiteCommand(stmt, _conn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to create table! ERROR:" + ex.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to database ERROR:" + ex.ToString());
                return;
            }
        }
        public void RegisterUser(string id, string username, string password)
        {
            string stmt = "INSERT INTO Login(id, username, parola) VALUES ('" + id + "', '" + username + "', '" + password + "')";
            SQLiteCommand cmd = new SQLiteCommand(stmt, _conn);
            try
            { 
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Inregistrare esuata! \n ERROR:" + ex.ToString());
                return;
            }
        }
        public bool CheckUser(string username)
        {
            string stmt = "SELECT COUNT(*) FROM Login WHERE username='"+ username +"'";
            SQLiteCommand cmd = new SQLiteCommand(stmt, _conn);
            try
            {
                int a=Convert.ToInt32(cmd.ExecuteScalar());
                if (a > 0)
                    return true;
                else
                    return false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nu s-a putut cauta userul! ERROR:" + ex.ToString());
                return false;
            }
        }
        public string GetIDFromUser(string username)
        {
            
            string id=null;
            string stmt = "SELECT id FROM Login WHERE username='" + username + "'";
            SQLiteCommand cmd = new SQLiteCommand(stmt, _conn);
            SQLiteDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erroare reader! ERROR:" + ex.ToString());
            }
           

            if(reader.Read())
            {

                
                id=reader.GetString(0);

            }
            reader.Close();
            return id;
        }
        public string GetPasswordFromUser(string username)
        {

            string password = null;
            string stmt = "SELECT parola FROM Login WHERE username='" + username + "'";
            SQLiteCommand cmd = new SQLiteCommand(stmt, _conn);
            SQLiteDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erroare reader! ERROR:" + ex.ToString());
            }


            if (reader.Read())
            {
                password = reader.GetString(0);
            }
            reader.Close();
            return password;
        }
    }
}
