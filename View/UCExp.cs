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
    public partial class UCExp : UserControl
    {
        public UCExp()
        {
            InitializeComponent();
        }
        public void UpdateUserName(string n)
        {
            labelUserName.Invoke(new Action(() => labelUserName.Text = n.ToString()));
        }
        public void UpdateLevel(int currentlevel, string currentprogress)
        {
            labelUserLevel.Invoke(new Action(() => labelUserLevel.Text = currentlevel.ToString()));
            labelUserNextLevel.Invoke(new Action(() => labelUserNextLevel.Text = currentprogress));
        }
    }
}
