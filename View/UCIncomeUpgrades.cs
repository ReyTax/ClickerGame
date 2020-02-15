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
    public partial class UCIncomeUpgrades : UserControl
    {
        public event Action buttonUpgradePassiveIncomeUnitAction;
        public event Action buttonUpgradePassiveIncomePercentageAction;
        public event Action buttonUpgradePassiveIncomeMultiplierAction;
        public UCIncomeUpgrades()
        {
            InitializeComponent();
            buttonUpgradePassiveIncomeMultiplier.FlatStyle = FlatStyle.Flat;
            buttonUpgradePassiveIncomePercentage.FlatStyle = FlatStyle.Flat;
            buttonUpgradePassiveIncomeUnit.FlatStyle = FlatStyle.Flat;
        }

        private void buttonUpgradePassiveIncomeUnit_Click(object sender, EventArgs e)
        {
            if (buttonUpgradePassiveIncomeUnitAction != null)
            {
                buttonUpgradePassiveIncomeUnitAction();
            }
        }

        private void buttonUpgradePassiveIncomePercentage_Click(object sender, EventArgs e)
        {
            if (buttonUpgradePassiveIncomePercentageAction != null)
            {
                buttonUpgradePassiveIncomePercentageAction();
            }
        }

        private void buttonUpgradePassiveIncomeMultiplier_Click(object sender, EventArgs e)
        {
            if (buttonUpgradePassiveIncomeMultiplierAction != null)
            {
                buttonUpgradePassiveIncomeMultiplierAction();
            }
        }
        public void IncreasePassiveUnitLevel(int n, int c)
        {
            labelUpgradePassiveUnitLevel.Invoke(new Action(() => labelUpgradePassiveUnitLevel.Text = n.ToString()));
            labelUpgradePassiveUnitCost.Invoke(new Action(() => labelUpgradePassiveUnitCost.Text = c.ToString()));
        }
        public void IncreasePassivePercentageLevel(int n, int c)
        {
            labelUpgradePassivePercentageLevel.Invoke(new Action(() => labelUpgradePassivePercentageLevel.Text = n.ToString()));
            labelUpgradePassivePercentageCost.Invoke(new Action(() => labelUpgradePassivePercentageCost.Text = c.ToString()));

        }
        public void IncreasePassiveMultiplierLevel(int n, int c)
        {
            labelUpgradePassiveMultiplierLevel.Invoke(new Action(() => labelUpgradePassiveMultiplierLevel.Text = n.ToString()));
            labelUpgradePassiveMultiplierCost.Invoke(new Action(() => labelUpgradePassiveMultiplierCost.Text = c.ToString()));
        }
        public void UpdatePassiveIncomePerTick(int n)
        {
            lavelPassiveIncomePerTick.Invoke(new Action(() => lavelPassiveIncomePerTick.Text = n.ToString()));
        }
    }
}
