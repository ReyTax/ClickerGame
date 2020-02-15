using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClickerGame.View;
using ClickerGame.Controller;
using ClickerGame.Model;
using System.Windows.Forms;
using View;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Xml;

namespace ClickerGame.ClickerGame
{
    public class Launcher
    {
        [STAThread]
        static void Main()
        {

            // Citire XML
            
            string xmlLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            xmlLocation = xmlLocation.Substring(6,xmlLocation.Length-15);
            xmlLocation = xmlLocation + "XMLPermission.xml";
            if (File.Exists(xmlLocation))
            {
                XmlTextReader rd = new XmlTextReader(xmlLocation);
                bool permission = false;
                while (rd.Read())
                    if (rd.NodeType == XmlNodeType.Element && rd.Name == "permission")
                    {
                        permission = bool.Parse(rd.ReadElementContentAsString());
                    }

                if (permission)
                {

                    // Scriere XML

                    if (!File.Exists("XmlOpenGame.xml"))
                    {
                        using (XmlWriter writer = XmlWriter.Create("XMLOpenGame.xml"))
                        {
                            writer.WriteStartDocument();
                            writer.WriteStartElement("data");
                            writer.WriteEndElement();
                            writer.Flush();
                        }

                    }
                    XmlDocument doc = new XmlDocument();
                    doc.Load("XmlOpenGame.xml");
                    XmlNode myXmlNode = doc.DocumentElement.FirstChild;
                    XmlElement myXmlElement = doc.CreateElement("data");
                    myXmlElement.SetAttribute("opendate", DateTime.Now.ToString());
                    doc.DocumentElement.InsertBefore(myXmlElement, myXmlNode);
                    doc.Save("XMLOpenGame.xml");
                    XmlTextReader myXmlReader = new XmlTextReader("XMLOpenGame.xml");
                    myXmlReader.Close();

                }
            }
            
            // verificare HMAC

            string secretkeyfilelocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + @"\SecretKey\key";
            secretkeyfilelocation = secretkeyfilelocation.Substring(6);
            string secrethmacfilelocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + @"\SecretKey\hmac";
            secrethmacfilelocation = secrethmacfilelocation.Substring(6);
            string gameDBlocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + @"\GameDB.sqlite";
            gameDBlocation = gameDBlocation.Substring(6);
            
            if (File.Exists(secretkeyfilelocation) && File.Exists(secrethmacfilelocation) && File.Exists(gameDBlocation))
            {
                
                byte[] secrekey = File.ReadAllBytes(secretkeyfilelocation);
                byte[] hmac = File.ReadAllBytes(secrethmacfilelocation);
                byte[] hmacValue = null;
                FileStream fin = new FileStream(gameDBlocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                KeyedHashAlgorithm cryptoProvider = new HMACSHA256(secrekey);
                hmacValue = cryptoProvider.ComputeHash(fin);
                fin.Close();
                if (System.Text.Encoding.UTF8.GetString(hmacValue) != System.Text.Encoding.UTF8.GetString(hmac))
                    MessageBox.Show("Baza de Date Modificata fara permis!");
            }

            // sfarsit verificare HMAC

            LoginScreen loginScreen = new LoginScreen();
            DBManipulationLogin loginData = new DBManipulationLogin();
            DBManipulationGame gameData = new DBManipulationGame();
            Connection connectionLogin = new Connection(loginData, gameData, loginScreen);
            loginScreen.ShowDialog();
        }
    }
}
