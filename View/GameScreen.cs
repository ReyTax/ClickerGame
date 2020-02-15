using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickerGame.View
{
    public partial class GameScreen : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public GameScreen()
        {
            InitializeComponent();
            // Scoate efectul de flickering din Graphics
            typeof(Panel).InvokeMember("DoubleBuffered",BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,null, ucClicker1, new object[] { true });
            buttonExit.FlatStyle = FlatStyle.Flat;
            SaveGame.FlatStyle = FlatStyle.Flat;
            EXP.FlatStyle = FlatStyle.Flat;
            ClickUpgrades.FlatStyle = FlatStyle.Flat;
            IncomeUpgrades.FlatStyle = FlatStyle.Flat;
            ClickMenu.FlatStyle = FlatStyle.Flat;
            ucExp1.BringToFront();
        }

        private void ClickMenu_Click(object sender, EventArgs e)
        {
            ucClicker1.BringToFront();
        }

        private void ClickUpgrades_Click(object sender, EventArgs e)
        {
            ucCllickerUpgrades1.BringToFront();
        }

        private void IncomeUpgrades_Click(object sender, EventArgs e)
        {
            ucIncomeUpgrades1.BringToFront();
        }

        private void EXP_Click(object sender, EventArgs e)
        {
            ucExp1.BringToFront();
        }

        private void SaveGame_Click(object sender, EventArgs e)
        {
            ucSave1.BringToFront();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if(ucSave1.GetSavingState()==false)
            this.Close();
        }
        public void UpdateClickUnitLevel(int n, int c)
        {
            ucCllickerUpgrades1.Invoke(new Action(() => ucCllickerUpgrades1.IncreaseClickUnitLevel(n, c)));
        }
        public void UpdateClickPercentageLevel(int n, int c)
        {
            ucCllickerUpgrades1.Invoke(new Action(() => ucCllickerUpgrades1.IncreaseClickPercentageLevel(n, c)));
        }
        public void UpdateClickMultiplierLevel(int n,int c)
        {
            ucCllickerUpgrades1.Invoke(new Action(() => ucCllickerUpgrades1.IncreaseClickMultiplierLevel(n, c)));
        }
        public void UpdatePassiveUnitLevel(int n, int c)
        {
            ucIncomeUpgrades1.Invoke(new Action(() => ucIncomeUpgrades1.IncreasePassiveUnitLevel(n, c)));
        }
        public void UpdatePassivePercentageLevel(int n, int c)
        {
            ucIncomeUpgrades1.Invoke(new Action(() => ucIncomeUpgrades1.IncreasePassivePercentageLevel(n, c)));
        }
        public void UpdatePassiveMultiplierLevel(int n, int c)
        {
            ucIncomeUpgrades1.Invoke(new Action(() => ucIncomeUpgrades1.IncreasePassiveMultiplierLevel(n, c)));
        }
        public void UpdateCurrentMoney(int n)
        {
            labelCurrentMoney.Invoke(new Action(() => labelCurrentMoney.Text = n.ToString()));
        }

        public void UpdateIncomePerTick(int n)
        {
            labelIncomePerTick.Invoke(new Action(() => labelIncomePerTick.Text = n.ToString()));
            ucIncomeUpgrades1.Invoke(new Action(() => ucIncomeUpgrades1.UpdatePassiveIncomePerTick(n)));
        }

        public void UpdateCurrentUser(string n)
        {
            ucExp1.Invoke(new Action(() => ucExp1.UpdateUserName(n)));
        }
        public void UpdateCurrentLevelAndProgress(int n,string currentprogress)
        {
            ucExp1.Invoke(new Action(() => ucExp1.UpdateLevel(n,currentprogress)));
        }
        public void UpdateIncomePerClick(int n)
        {
            ucCllickerUpgrades1.Invoke(new Action(() => ucCllickerUpgrades1.UpdateClickIncome(n)));
        }
        private void GameScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
