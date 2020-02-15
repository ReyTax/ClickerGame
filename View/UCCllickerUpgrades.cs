using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickerGame.View
{
    public partial class UCCllickerUpgrades : UserControl
    {
        public event Action buttonUpgradeClickIncomeUnitAction;
        public event Action buttonUpgradeClickIncomePercentageAction;
        public event Action buttonUpgradeClickIncomeMultiplierAction;

        public UCCllickerUpgrades()
        {
            InitializeComponent();
            buttonUpgradeClickIncomeMultiplier.FlatStyle = FlatStyle.Flat;
            buttonUpgradeClickIncomePercentage.FlatStyle = FlatStyle.Flat;
            buttonUpgradeClickIncomeUnit.FlatStyle = FlatStyle.Flat;
        }

        private void buttonUpgradeClickIncomeUnit_Click(object sender, EventArgs e)
        {
            if (buttonUpgradeClickIncomeUnitAction != null)
            {
                buttonUpgradeClickIncomeUnitAction();
            }
        }

        private void buttonUpgradeClickIncomePercentage_Click(object sender, EventArgs e)
        {
            if (buttonUpgradeClickIncomePercentageAction != null)
            {
                buttonUpgradeClickIncomePercentageAction();
            }
        }

        private void buttonUpgradeClickIncomeMultiplier_Click(object sender, EventArgs e)
        {
            if (buttonUpgradeClickIncomeMultiplierAction != null)
            {
                buttonUpgradeClickIncomeMultiplierAction();
            }
        }
        public void IncreaseClickUnitLevel(int n,int c)
        {
            labelUpgradeClickUnitLevel.Invoke(new Action(() => labelUpgradeClickUnitLevel.Text = n.ToString()));
            labelUpgradeClickUnitCost.Invoke(new Action(() => labelUpgradeClickUnitCost.Text = c.ToString()));
        }
        public void IncreaseClickPercentageLevel(int n,int c)
        {
            labelUpgradeClickPercentageLevel.Invoke(new Action(() => labelUpgradeClickPercentageLevel.Text = n.ToString()));
            labelUpgradeClickPercentageCost.Invoke(new Action(() => labelUpgradeClickPercentageCost.Text = c.ToString()));

        }
        public void IncreaseClickMultiplierLevel(int n,int c)
        {
            labelUpgradeClickMultiplierLevel.Invoke(new Action(() => labelUpgradeClickMultiplierLevel.Text = n.ToString()));
            labelUpgradeClickMultiplierCost.Invoke(new Action(() => labelUpgradeClickMultiplierCost.Text = c.ToString()));
        }
        public void UpdateClickIncome(int n)
        {
            labelClickIncome.Invoke(new Action(() => labelClickIncome.Text = n.ToString()));
        }
    }
}
