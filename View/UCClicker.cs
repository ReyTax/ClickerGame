using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Properties;
using System.Diagnostics;
using System.Threading;

namespace ClickerGame.View
{
    
    public partial class UCClicker : UserControl
    {
        Random rnd=new Random();
        Ball ball;
        TraceSwitch tr1;
        private volatile Object locker = new Object();
        Thread thread;
        public UCClicker()
        {
            InitializeComponent();
            timerGameLoop.Start();
            ball = new Ball(200,200);

            tr1 = new TraceSwitch("Switch1", "Text Control Trace");
            Trace.AutoFlush = true;
        }
        public event Action ballHit;
        int _cursX = 0;
        int _cursY = 0;
        private void timerGameLoop_Tick(object sender, EventArgs e)
        {

            Updateball();
            this.Refresh();
        }
        private void Updateball()
        {
            ball.Update(rnd.Next(100, 520), rnd.Next(100,350));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ball.DrawImage(g);
            // important pentru functionare
            base.OnPaint(e);
        }
        private void UCClicker_MouseClick(object sender, MouseEventArgs e)
        {
            _cursX = e.X;
            _cursY = e.Y;
            if (tr1.TraceInfo)
            {
                Trace.TraceInformation("click : " + _cursX + " " + _cursY);
                Trace.TraceInformation("ball : " + ball.ball.X + " " + ball.ball.Y + " " + ball.ball.Width + " " + ball.ball.Height);
            }
            
            if (ball.HitDetection(_cursX, _cursY))
            {
                thread = new Thread(BallHitMessage);
                thread.Start();
                Updateball();
                if (ballHit != null)
                {
                    ballHit();
                }
                timerGameLoop.Stop();
                timerGameLoop.Start();
                
            }
            
            this.Refresh();
        }
        private void BallHitMessage()
        {
            lock (locker)
            {
                labelHit.Invoke(new Action(() => labelHit.Text = "HIT"));
                labelHit.Invoke(new Action(() => labelHit.Refresh()));
                Thread.Sleep(200);
                labelHit.Invoke(new Action(() => labelHit.Text = ""));
            }
        }
    }
}
