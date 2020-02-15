using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickerGame.View
{
    public partial class LoginScreen : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        
        public LoginScreen()
        {
            InitializeComponent();
            exitButton.FlatStyle = FlatStyle.Flat;
        }
        public event Action loginButtonAction;
        public string GetUsername() { return this.userTextbox.Text; }
        public string GetPassword() { return this.passTextbox.Text; }
        private void loginButton_Click(object sender, EventArgs e)
        {
            if(loginButtonAction != null)
            {
                loginButtonAction();
            }
            
        }
        public void Registered()
        {
            MessageBox.Show("Inregistrare cu Succes!");
        }
        public void LoginSucces()
        {
            MessageBox.Show("Logare cu Succes!");
        }
        public void PasswordFailed()
        {
            MessageBox.Show("Parola Gresita!");
        }
        public void FormatError()
        {
            MessageBox.Show("Datele nu sunt acceptate!");
        }

        private void LoginScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
