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
    public class DBManipulationGame
    {
        private SQLiteConnection _conn;
        public void ConnectToGameDB()
        {
            if (!File.Exists("GameDB.sqlite"))
            {
                SQLiteConnection.CreateFile("GameDB.sqlite");
            }
            try
            {
                _conn = new SQLiteConnection("DataSource=GameDB.sqlite;Version=3;");
                _conn.Open();
                string stmt = "CREATE TABLE IF NOT EXISTS Game(id BLOB, playerlevel TXT, playerlevelprogress TXT, currentmoney TXT, clickunitlevel TXT, clickpercentagelevel TXT, clickmultiplierlevel TXT, passiveunitlevel TXT, passivepercentagelevel TXT, passivemultiplierlevel TXT)";
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
        public void RegisterUser(string id, string playerlevel, string playerlevelprogress, string currentmoney, string clickunitlevel, string clickpercentagelevel, string clickmultiplierlevel, string passiveunitlevel, string passivepercentagelevel,string passivemultiplierlevel)
        {
            string stmt = "INSERT INTO Game(id, playerlevel, playerlevelprogress, currentmoney, clickunitlevel, clickpercentagelevel, clickmultiplierlevel, passiveunitlevel, passivepercentagelevel, passivemultiplierlevel) VALUES ('" + id + "', '" + playerlevel + "', '" + playerlevelprogress + "', '" + currentmoney + "', '"  + clickunitlevel + "', '" + clickpercentagelevel + "', '" + clickmultiplierlevel + "', '" + passiveunitlevel + "', '" + passivepercentagelevel + "', '" + passivemultiplierlevel + "')";
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
        
        public List<string> GetDataFromID(string id)
        {

            List<string> data = new List<string>();
            string stmt = "SELECT * FROM Game WHERE id='" + id + "'";
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

            while (reader.Read())
            {

                data.Add(reader.GetValue(1).ToString());
                data.Add(reader.GetValue(2).ToString());
                data.Add(reader.GetValue(3).ToString());
                data.Add(reader.GetValue(4).ToString());
                data.Add(reader.GetValue(5).ToString());
                data.Add(reader.GetValue(6).ToString());
                data.Add(reader.GetValue(7).ToString());
                data.Add(reader.GetValue(8).ToString());
                data.Add(reader.GetValue(9).ToString());

            }
            reader.Close();
            return data;
        }

        public void UpdateGameData(string id, string playerlevel,string playerlevelprogress, string currentMoney, string clickunitlevel, string clickpercentagelevel, string clickmultiplierlevel, string passiveunitlevel, string passivepercentagelevel, string passivemultiplierlevel)
        {
            string stmt = "UPDATE Game SET playerlevel='"+ playerlevel + "', playerlevelprogress='" + playerlevelprogress + "', currentmoney='" + currentMoney + "', clickunitlevel='" + clickunitlevel + "', clickpercentagelevel='" + clickpercentagelevel + "', clickmultiplierlevel='" + clickmultiplierlevel + "', passiveunitlevel='" + passiveunitlevel + "', passivepercentagelevel='" + passivepercentagelevel + "', passivemultiplierlevel='" + passivemultiplierlevel + "' WHERE id='"+id+"'";
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
       
    }
}
