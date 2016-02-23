using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using ZACKUpdater;
using System.Threading;

namespace SimplyUpdate
{
    public partial class UpdateWindow : Form
    {
        Uri address = new Uri(@"https://dl.dropboxusercontent.com/u/42345729/bluerose.zip");
        string program = "BlueRoseLauncher.exe";

        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void UpdateWindow_Load(object sender, EventArgs e)
        {
            useLessProgressBar.Style = ProgressBarStyle.Marquee;
            useLessProgressBar.MarqueeAnimationSpeed = 50;

            try
            {
                UpdateInfo.SelfUpdate(program, address, "update.zip");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                try
                {
                    Process.Start(program);
                    Application.Exit();
                }
                catch
                {
                    Application.Exit();
                }
            }
        }
        
    }
}
