using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace ClickerGame.View
{
    public partial class UCSave : UserControl
    {
        public event Action buttonSaveGameAction;
        Thread thread;
        private volatile Object locker = new Object();
        static bool saving=false;
        public UCSave()
        {
            InitializeComponent();
            buttonSaveGame.FlatStyle = FlatStyle.Flat;
            buttonSaveGame.FlatAppearance.BorderSize = 0;
            
        }
        public bool GetSavingState()
        {
            return saving;
        }
        private void buttonSaveGame_Click(object sender, EventArgs e)
        {
            thread = new Thread(SaveLabelUpdate);
            thread.Start();
            if (buttonSaveGameAction != null)
            {
                buttonSaveGameAction();
            }
            
        }
        private void SaveLabelUpdate()
        {
            lock (locker)
            {
                saving = true;
                labelSalvare.Invoke(new Action(() => labelSalvare.Text = "SALVAT!"));
                labelSalvare.Invoke(new Action(() => labelSalvare.Refresh()));
                Thread.Sleep(500);
                labelSalvare.Invoke(new Action(() => labelSalvare.Text = ""));
                saving = false;
            }
        }
        
    }
}
