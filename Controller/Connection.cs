using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ClickerGame.Model;
using ClickerGame.View;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;
using GameDataInitializer;
using System.Timers;
using System.Diagnostics;

namespace ClickerGame.Controller
{

    public class Connection
    {
        
        Assembly fileManager;
        Assembly stringValidation;
        LoginScreen loginScreen;
        DBManipulationLogin loginDB;
        DBManipulationGame gameDB;
        GameScreen gameScreen;
        
        string projectDirectoryPath;
        string idCurrentConnection;
        string userCurrentConnection;

        TraceSwitch tr1;

        private static Timer timerpassiveIncomeTick;
        List<string> dataGameInitializer;
        public Connection(DBManipulationLogin currentManipulationLogin,DBManipulationGame currentManipulationGame, LoginScreen currentLoginScreen)
        {
            if (File.Exists("infoLog.txt"))
            {
                File.Delete("infoLog.txt");
            }
            TextWriterTraceListener txtLst;
            tr1 = new TraceSwitch("Switch1", "Text Control Trace");
            FileStream logFile;
            logFile = new FileStream("infoLog.txt", FileMode.OpenOrCreate);

            txtLst = new TextWriterTraceListener(logFile);
            Trace.Listeners.Add(txtLst);
            Trace.AutoFlush = true;


            if (tr1.TraceInfo)
                Trace.TraceInformation(DateTime.Now.ToString("h\\:mm : ") + "Conexiune effectuata");

            loginScreen = currentLoginScreen;
            loginDB = currentManipulationLogin;
            gameDB = currentManipulationGame;
            
            gameScreen = new GameScreen();
            dataGameInitializer = new List<string>();
            
            // Crearea conexiunilor intre emitatorul actiunilor si receptor

            loginScreen.loginButtonAction += HandleConnect;
            gameScreen.ucClicker1.ballHit += HandleBallHit;
            gameScreen.ucCllickerUpgrades1.buttonUpgradeClickIncomeUnitAction += HandlebuttonUpgradeClickIncomeUnitAction;
            gameScreen.ucCllickerUpgrades1.buttonUpgradeClickIncomePercentageAction += HandlebuttonUpgradeClickIncomePercentageAction;
            gameScreen.ucCllickerUpgrades1.buttonUpgradeClickIncomeMultiplierAction += HandlebuttonUpgradeClickIncomeMultiplierAction;
            gameScreen.ucIncomeUpgrades1.buttonUpgradePassiveIncomeUnitAction += HandlebuttonUpgradePassiveIncomeUnitAction;
            gameScreen.ucIncomeUpgrades1.buttonUpgradePassiveIncomePercentageAction += HandlebuttonUpgradePassiveIncomePercentageAction;
            gameScreen.ucIncomeUpgrades1.buttonUpgradePassiveIncomeMultiplierAction += HandlebuttonUpgradePassiveIncomeMultiplierAction;
            gameScreen.ucSave1.buttonSaveGameAction += HandlebuttonSaveGameAction;

            timerpassiveIncomeTick = new Timer(1000);
            timerpassiveIncomeTick.Elapsed += new ElapsedEventHandler(PassiveIncomeTick);
            timerpassiveIncomeTick.AutoReset = true;
            
        }
        private void HandleConnect()
        {
            if (tr1.TraceInfo)
                Trace.TraceInformation(DateTime.Now.ToString("h\\:mm : ") + "HandleConnect apelat!");

            projectDirectoryPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            projectDirectoryPath = projectDirectoryPath.Substring(6);
            projectDirectoryPath = projectDirectoryPath.Substring(0, projectDirectoryPath.Length - 18);

            // Incarcare assembly-uri

            fileManager = Assembly.LoadFile(projectDirectoryPath + @"FileManager\bin\Debug\FileManager.dll");
            stringValidation = Assembly.LoadFile(projectDirectoryPath + @"StringValidation\bin\Debug\StringValidation.dll");
            projectDirectoryPath = null;
            
            // Instantare obiecte din assembly-uri

            dynamic keyivsaver = Activator.CreateInstance(fileManager.GetType("FileManager.KeyAndIVSaver"), null);
            dynamic stringverification = Activator.CreateInstance(stringValidation.GetType("StringValidation.StringVerification"), null);
            
            // Connectare la bazele de date

            loginDB.ConnectToLoginDB();
            gameDB.ConnectToGameDB();

            if (tr1.TraceInfo)
                Trace.TraceInformation(DateTime.Now.ToString("h\\:mm : ") + "Bazele de date au fost connectate cu succes!");

            string username = loginScreen.GetUsername();
            string password = loginScreen.GetPassword();
            userCurrentConnection = username;

            // Verificare date de intrare valide

            if (stringverification.StringVerif(username) && stringverification.StringVerif(password))
            {
                if (tr1.TraceInfo)
                    Trace.TraceInformation(DateTime.Now.ToString("h\\:mm : ") + "Datele introduse au fost valide!");

                // Daca user-ul nu se afla in baza de date:
                // 1.Creez un ID unic
                // 2.Dau Hash la ID si il bag in gameDB impreuna cu alte date
                // 3.ID-ul fara hash il criptez si salvez IV/Key
                // 4.Dau Hash la parola
                // 5.Salvez datele in LoginDB
                // User nou Inregistrat

                // Daca user-ul se afla in baza de date:
                // 1.Dau Hash la parola si verific daca coincide cu cea din baza de date
                // 2.Iau ID-ul din LoginDB si il decriptez
                // 3.Dau Hash la ID si il caut in gameDB
                // 4.Actualizez datele jocului cu cele salvate in gameDB
                // User logat


                if (loginDB.CheckUser(username) == false)
                {

                    if (tr1.TraceInfo)
                        Trace.TraceInformation(DateTime.Now.ToString("h\\:mm : ") + "Creare user nou!");

                    // Creez un ID unic

                    Random rnd = new Random();
                    string id = username + rnd.Next(1, 10000000).ToString();
                    string idclone = id;

                    // Hash-ez id-ul unic si il bag in gameDB impreuna cu alte valori initiale

                    byte[] inp = System.Text.Encoding.UTF8.GetBytes(id);
                    HashAlgorithm hcryptoProvider = new SHA256CryptoServiceProvider();
                    byte[] hashValue = null;
                    hashValue = hcryptoProvider.ComputeHash(inp);
                    id = BitConverter.ToString(hashValue).Replace("-", "");
                    idCurrentConnection = id;
                    gameDB.RegisterUser(id, SDI.constplayerLevel.ToString(),SDI.constplayerlevelprogress.ToString(), SDI.constcurrentMoney.ToString(), SDI.constclickunitlevel.ToString(), SDI.constclickpercentagelevel.ToString(), SDI.constclickmultiplierlevel.ToString(), SDI.constpassiveunitlevel.ToString(), SDI.constpassivepercentagelevel.ToString(), SDI.constpassivemultiplierlevel.ToString());
                    SDI.GameDataNewUserInitialization();

                    id = idclone;

                    //Criptez ID-ul

                    AesCryptoServiceProvider cryptoProvider = new AesCryptoServiceProvider();
                    ICryptoTransform encryptor = cryptoProvider.CreateEncryptor();
                    MemoryStream memStream = new MemoryStream();
                    CryptoStream cryptStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write);
                    StreamWriter wrStream = new StreamWriter(cryptStream);
                    byte[] encIV = cryptoProvider.IV;
                    byte[] encKey = cryptoProvider.Key;

                    //Salvez cheia si IV intr-un fisier local

                    keyivsaver.ByteArrayToFile(username + "Key", encKey);
                    keyivsaver.ByteArrayToFile(username + "IV", encIV);


                    wrStream.Write(id);
                    wrStream.Close();
                    cryptStream.Close();
                    memStream.Close();
                    byte[] benc = memStream.ToArray();

                    // Transform din byte array in hexadecimal string

                    id = BitConverter.ToString(benc).Replace("-", "");

                    // calculare HASH parola

                    inp = System.Text.Encoding.UTF8.GetBytes(password);
                    hcryptoProvider = new SHA256CryptoServiceProvider();
                    hashValue = null;
                    hashValue = hcryptoProvider.ComputeHash(inp);
                    password = BitConverter.ToString(hashValue).Replace("-", "");

                    // Insertare in Tabel

                    loginDB.RegisterUser(id, username, password);

                    // Inceput Generare HMAC
                    
                    string HMACFileKey = null;
                    HMACFileKey = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + @"\SecretKey\" + "key";
                    HMACFileKey = HMACFileKey.Substring(6);
                    Directory.CreateDirectory(Path.GetDirectoryName(HMACFileKey)); 

                    string HMACFileMessage = null;
                    HMACFileMessage = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + @"\SecretKey\" + "hmac";
                    HMACFileMessage = HMACFileMessage.Substring(6);
                    Directory.CreateDirectory(Path.GetDirectoryName(HMACFileMessage));

                    string gameDBDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                    gameDBDirectory = gameDBDirectory.Substring(6);
                    byte[] secretKey = new byte[128];
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    rng.GetBytes(secretKey);
                    FileStream fin = new FileStream(gameDBDirectory + @"\GameDB.sqlite",FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    KeyedHashAlgorithm HcryptoProvider = new HMACSHA256(secretKey);
                    byte[] hmacValue = null;
                    hmacValue = HcryptoProvider.ComputeHash(fin);
                    fin.Close();
                    using (var fs = new FileStream(HMACFileKey, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(secretKey, 0, secretKey.Length);
                    }
                    using (var fs = new FileStream(HMACFileMessage, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(hmacValue, 0, hmacValue.Length);
                    }

                    // Sfarsit Generare HMAC
                    
                    loginScreen.Registered();
                    loginScreen.Dispose();
                    
                    timerpassiveIncomeTick.Enabled = true;
                    gameScreen.ShowDialog();
                }
                else
                {
                    
                    // HASH parola

                    string hpassword = loginDB.GetPasswordFromUser(username);
                    byte[] inp = System.Text.Encoding.UTF8.GetBytes(password);
                    HashAlgorithm hcryptoProvider = new SHA256CryptoServiceProvider();
                    byte[] hashValue = null;
                    hashValue = hcryptoProvider.ComputeHash(inp);
                    password = BitConverter.ToString(hashValue).Replace("-", "");

                    if (password.CompareTo(hpassword) == 0)
                    {
                        if (tr1.TraceInfo)
                            Trace.TraceInformation(DateTime.Now.ToString("h\\:mm : ") + "Logare user existent!");

                        // Decriptez id-ul pentru a cauta datele user-ului in gameDB

                        string id = loginDB.GetIDFromUser(username);
                        int NumberChars = id.Length;

                        byte[] bdec = new byte[NumberChars / 2];
                        for (int i = 0; i < NumberChars; i += 2)
                            bdec[i / 2] = Convert.ToByte(id.Substring(i, 2), 16);

                        AesCryptoServiceProvider cryptoProvider = new AesCryptoServiceProvider();
                        byte[] encKey = keyivsaver.FileToByteArray(username + "Key");
                        byte[] encIV = keyivsaver.FileToByteArray(username + "IV"); ;
                        ICryptoTransform decryptor = cryptoProvider.CreateDecryptor(encKey, encIV);
                        MemoryStream memStream = new MemoryStream(bdec);
                        CryptoStream cryptStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read);
                        StreamReader swEncrypt = new StreamReader(cryptStream);
                        id = swEncrypt.ReadToEnd();

                        // Hash id

                        inp = System.Text.Encoding.UTF8.GetBytes(id);
                        hcryptoProvider = new SHA256CryptoServiceProvider();
                        hashValue = null;
                        hashValue = hcryptoProvider.ComputeHash(inp);
                        id = BitConverter.ToString(hashValue).Replace("-", "");
                        idCurrentConnection = id;

                        dataGameInitializer = gameDB.GetDataFromID(id);
                        SDI.GameDataExistentUserInitialization(Int32.Parse(dataGameInitializer[0]), Int32.Parse(dataGameInitializer[1]), Int32.Parse(dataGameInitializer[2]), Int32.Parse(dataGameInitializer[3]), Int32.Parse(dataGameInitializer[4]), Int32.Parse(dataGameInitializer[5]), Int32.Parse(dataGameInitializer[6]), Int32.Parse(dataGameInitializer[7]), Int32.Parse(dataGameInitializer[8]));
                        
                        cryptStream.Close();
                        memStream.Close();
                        swEncrypt.Close();
                        loginScreen.LoginSucces();
                        loginScreen.Dispose();

                        timerpassiveIncomeTick.Enabled = true;
                        gameScreen.ShowDialog();
                    }
                    else
                        loginScreen.PasswordFailed();

                }
            }
            else
                loginScreen.FormatError();
        }
        private void UpdateAllGameData()
        {
            gameScreen.UpdateClickUnitLevel(SDI.clickunitlevel, SDI.clickunitcost);
            gameScreen.UpdateClickPercentageLevel(SDI.clickpercentagelevel, SDI.clickpercentagecost);
            gameScreen.UpdateClickMultiplierLevel(SDI.clickmultiplierlevel, SDI.clickmultipliercost);
            gameScreen.UpdatePassiveUnitLevel(SDI.passiveunitlevel, SDI.passiveunitcost);
            gameScreen.UpdatePassivePercentageLevel(SDI.passivepercentagelevel, SDI.passivepercentagecost);
            gameScreen.UpdatePassiveMultiplierLevel(SDI.passivemultiplierlevel, SDI.passivemultipliercost);
            gameScreen.UpdateIncomePerTick(SDI.passiveIncomePerTick);
            gameScreen.UpdateIncomePerClick(SDI.clickIncomePerClick);
            gameScreen.UpdateCurrentMoney(SDI.currentMoney);
            gameScreen.UpdateCurrentUser(userCurrentConnection);
            gameScreen.UpdateCurrentLevelAndProgress(SDI.playerLevel, SDI.playerlevelprogress.ToString()+"/"+ SDI.playerlevelprogressneeded.ToString());
        }
        private void PassiveIncomeTick(object source, ElapsedEventArgs e)
        {
            SDI.PassiveIncomePerTick();
            SDI.ClickIncomePerClick();
            SDI.IncrementPassiveCurrentMoney();
            UpdateAllGameData();
        }

        private void HandleBallHit()
        {

            SDI.IncrementClickCurrentMoney();
            SDI.playerlevelprogress++;
            if (SDI.playerlevelprogress >= SDI.playerlevelprogressneeded)
            {
                SDI.playerlevelprogress = 0;
                SDI.playerLevel++;
            }
            UpdateAllGameData();
        }
        private void HandlebuttonUpgradeClickIncomeUnitAction()
        {
            SDI.IncrementClickUnitLevel();
            SDI.ClickIncomePerClick();
            UpdateAllGameData();
        }
        private void HandlebuttonUpgradeClickIncomePercentageAction()
        {
            SDI.IncrementClickPercentageLevel();
            SDI.ClickIncomePerClick();
            UpdateAllGameData();
        }
        private void HandlebuttonUpgradeClickIncomeMultiplierAction()
        {
            SDI.IncrementClickMultiplierLevel();
            SDI.ClickIncomePerClick();
            UpdateAllGameData();
        }
        private void HandlebuttonUpgradePassiveIncomeUnitAction()
        {
            SDI.IncrementPassiveUnitLevel();
            SDI.PassiveIncomePerTick();
            UpdateAllGameData();
        }
        private void HandlebuttonUpgradePassiveIncomePercentageAction()
        {
            SDI.IncrementPassivePercentageLevel();
            SDI.PassiveIncomePerTick();
            UpdateAllGameData();
        }
        private void HandlebuttonUpgradePassiveIncomeMultiplierAction()
        {
            SDI.IncrementPassiveMultiplierLevel();
            SDI.PassiveIncomePerTick();
            UpdateAllGameData();
        }
        private void HandlebuttonSaveGameAction()
        {
            if (tr1.TraceInfo)
                Trace.TraceInformation(DateTime.Now.ToString("h\\:mm : ") + "Jocul a fost salvat cu succes!");

            gameDB.UpdateGameData(idCurrentConnection,SDI.playerLevel.ToString(),SDI.playerlevelprogress.ToString(),SDI.currentMoney.ToString(), SDI.clickunitlevel.ToString(), SDI.clickpercentagelevel.ToString(), SDI.clickmultiplierlevel.ToString(), SDI.passiveunitlevel.ToString(), SDI.passivepercentagelevel.ToString(), SDI.passivemultiplierlevel.ToString());

            // Inceput Generare HMAC

            string gameDBlocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + @"\GameDB.sqlite";
            gameDBlocation = gameDBlocation.Substring(6);
            string HMACFileKey = null;
            HMACFileKey = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + @"\SecretKey\" + "key";
            HMACFileKey = HMACFileKey.Substring(6);
            Directory.CreateDirectory(Path.GetDirectoryName(HMACFileKey));

            string HMACFileMessage = null;
            HMACFileMessage = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + @"\SecretKey\" + "hmac";
            HMACFileMessage = HMACFileMessage.Substring(6);
            Directory.CreateDirectory(Path.GetDirectoryName(HMACFileMessage));

            byte[] secretKey = new byte[128];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(secretKey);
            FileStream fin = new FileStream(gameDBlocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            KeyedHashAlgorithm HcryptoProvider = new HMACSHA256(secretKey);
            byte[] hmacValue = null;
            hmacValue = HcryptoProvider.ComputeHash(fin);
            fin.Close();
            using (var fs = new FileStream(HMACFileKey, FileMode.Create, FileAccess.Write))
            {
                fs.Write(secretKey, 0, secretKey.Length);
            }
            using (var fs = new FileStream(HMACFileMessage, FileMode.Create, FileAccess.Write))
            {
                fs.Write(hmacValue, 0, hmacValue.Length);
            }

            // Sfarsit Generare HMAC
        }
    }

}
