using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDataInitializer
{
    // Static Data Initializer
    public static class SDI
    {
        //Variabile Constante pentru Initializare Cont Nou
        public const int constplayerLevel = 1;
        public const int constplayerlevelprogress = 0;
        public const int constplayerlevelprogressneeded = 100;
        public const int constcurrentMoney = 0;
        public const int constpassiveIncomePerTick = 0;
        public const int constclickIncomePerClick = 0;
        public const int constclickunitlevel = 0;
        public const int constclickpercentagelevel = 0;
        public const int constclickmultiplierlevel = 0;
        public const int constclickunitcost = 5;
        public const int constclickunitcostincrease = 5;
        public const int constclickpercentagecost = 10;
        public const int constclickpercentagecostincrease = 10;
        public const int constclickmultipliercost = 10;
        public const int constclickmultipliercostincrease = 10;
        public const int constpassiveunitlevel = 0;
        public const int constpassivepercentagelevel = 0;
        public const int constpassivemultiplierlevel = 0;
        public const int constpassiveunitcost = 5;
        public const int constpassiveunitcostincrease = 5;
        public const int constpassivepercentagecost = 10;
        public const int constpassivepercentagecostincrease = 10;
        public const int constpassivemultipliercost = 10;
        public const int constpassivemultipliercostincrease = 10;

        //Variabile pentru Initializare Cont existent
        public static int playerLevel = 1;
        public static int playerlevelprogress = 0;
        public static int playerlevelprogressneeded = 100;
        public static int currentMoney = 0;
        public static int passiveIncomePerTick = 0;
        public static int clickIncomePerClick = 0;
        public static int clickunitlevel = 1;
        public static int clickpercentagelevel = 0;
        public static int clickmultiplierlevel = 1;
        public static int clickunitcost = 5;
        public static int clickpercentagecost = 10;
        public static int clickmultipliercost = 20;
        public static int passiveunitlevel = 1;
        public static int passivepercentagelevel = 0;
        public static int passivemultiplierlevel = 1;
        public static int passiveunitcost = 5;
        public static int passivepercentagecost = 10;
        public static int passivemultipliercost = 20;

        //Metode Incrementare level si cost

        public static void IncrementClickUnitLevel()
        {
            if (clickunitcost <= currentMoney)
            {
                currentMoney = currentMoney - clickunitcost;
                clickunitlevel++;
                clickunitcost = clickunitcost + constclickunitcostincrease;
            }
            ClickIncomePerClick();
        }
        public static void IncrementClickPercentageLevel()
        {
            if (clickpercentagecost <= currentMoney)
            {
                currentMoney = currentMoney - clickpercentagecost;
                clickpercentagelevel++;
                clickpercentagecost = clickpercentagecost + constclickpercentagecostincrease;
            }
            ClickIncomePerClick();
        }
        public static void IncrementClickMultiplierLevel()
        {
            if (clickmultipliercost <= currentMoney)
            {
                currentMoney = currentMoney - clickmultipliercost;
                clickmultiplierlevel++;
                clickmultipliercost = clickmultipliercost * constclickmultipliercostincrease;
            }
            ClickIncomePerClick();
        }
        public static void ClickIncomePerClick()
        {
            double currentmoneydouble = ((1 + clickunitlevel) * Math.Pow(2, clickmultiplierlevel)) + ((clickunitlevel * Math.Pow(2, clickmultiplierlevel)) * ((double)clickpercentagelevel / 100));
            clickIncomePerClick = (int)currentmoneydouble;
        }
        public static void IncrementClickCurrentMoney()
        {
            ClickIncomePerClick();
            currentMoney = currentMoney + clickIncomePerClick;
        }

        public static void IncrementPassiveUnitLevel()
        {
            if (passiveunitcost <= currentMoney)
            {
                currentMoney = currentMoney - passiveunitcost;
                passiveunitlevel++;
                passiveunitcost = passiveunitcost + constpassiveunitcostincrease;
            }
        }
        public static void IncrementPassivePercentageLevel()
        {
            if (passivepercentagecost <= currentMoney)
            {
                currentMoney = currentMoney - passivepercentagecost;
                passivepercentagelevel++;
                passivepercentagecost = passivepercentagecost + constpassivepercentagecostincrease;
            }
        }
        public static void IncrementPassiveMultiplierLevel()
        {
            if (passivemultipliercost <= currentMoney)
            {
                currentMoney = currentMoney - passivemultipliercost;
                passivemultiplierlevel++;
                passivemultipliercost = passivemultipliercost * constpassivemultipliercostincrease;
            }

        }

        public static void IncrementPassiveCurrentMoney()
        {
            currentMoney = currentMoney + passiveIncomePerTick;
        }
        
        public static void PassiveIncomePerTick()
        {
            double currentmoneydouble = (passiveunitlevel * Math.Pow(2,passivemultiplierlevel)) + ((passiveunitlevel * Math.Pow(2, passivemultiplierlevel)) * ((double)passivepercentagelevel / 100));
            passiveIncomePerTick = (int)currentmoneydouble;
        }
        public static void CostActualization()
        {
            clickunitcost = constclickunitcostincrease * clickunitlevel + constclickunitcost;
            clickpercentagecost = constclickpercentagecostincrease * clickpercentagelevel + constclickpercentagecost;
            clickmultipliercost = constclickmultipliercost * (int)Math.Pow(constclickmultipliercostincrease, clickmultiplierlevel);
            passiveunitcost = constpassiveunitcostincrease * passiveunitlevel + constpassiveunitcost;
            passivepercentagecost = constpassivepercentagecostincrease * passivepercentagelevel + constpassivepercentagecost;
            passivemultipliercost = constpassivemultipliercost * (int)Math.Pow(constpassivemultipliercostincrease,passivemultiplierlevel);
        }
        public static void GameDataNewUserInitialization()
        {
            playerLevel = constplayerLevel;
            playerlevelprogress = constplayerlevelprogress;
            playerlevelprogressneeded = constplayerlevelprogressneeded;
            currentMoney = constcurrentMoney;
            clickunitlevel = constclickunitlevel;
            clickpercentagelevel = constclickpercentagelevel;
            clickmultiplierlevel = constclickmultiplierlevel;
            passiveunitlevel = constpassiveunitlevel;
            passivepercentagelevel = constpassivepercentagelevel;
            passivemultiplierlevel = constpassivemultiplierlevel;
            PassiveIncomePerTick();
            CostActualization();
        }
        public static void GameDataExistentUserInitialization(int _playerLevel,int _playerlevelprogress, int _currentMoney, int _clickunitlevel, int _clickpercentagelevel, int _clickmultiplierlevel, int _passiveunitlevel, int _passivepercentagelevel, int _passivemultiplierlevel)
        {
            playerLevel = _playerLevel;
            playerlevelprogress = _playerlevelprogress;
            currentMoney = _currentMoney;
            clickunitlevel = _clickunitlevel;
            clickpercentagelevel = _clickpercentagelevel;
            clickmultiplierlevel = _clickmultiplierlevel;
            passiveunitlevel = _passiveunitlevel;
            passivepercentagelevel = _passivepercentagelevel;
            passivemultiplierlevel = _passivemultiplierlevel;
            PassiveIncomePerTick();
            CostActualization();
        }
    }
}
