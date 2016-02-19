// Copyright(C) 2016  Blue Rose Project

// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using BlueRose.Distro;

namespace BlueRoseApp
{
    public partial class BlueRoseGUI : Form
    {
        private string errorBtn = "ERROR";
        WebClient client = new WebClient();
        string unpackerZip = "bluerose.zip";
        string netBuild = "#" + BlueRose.distNum();
        string buildFile = "fsobuild";
        string fsoConfigFile = Environment.CurrentDirectory + @"\FreeSO.exe.config";
        string fsoConfigNormalBackup = Environment.CurrentDirectory + @"\FreeSO.exe.config.backup";
        string fsoConfigUserBackup = Environment.CurrentDirectory + @"\FreeSO.exe.config.userbackup";

        public BlueRoseGUI()
        {
            try
            {
                InitializeComponent();

                this.MaximizeBox = false;
                this.MinimizeBox = false;

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            BlueRose.StartFSO("FreeSO.exe");
        }

        private void devBtn_Click(object sender, EventArgs e)
        {
            BlueRose.StartFSO("FSO.IDE.exe");
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            BlueRose.GC();

            try
            {
                localBuild.Text = BlueRose.readBuild(buildFile);
                onlineBuildLabel.Text = "#" + BlueRose.distNum();
            }
            catch
            {
                onlineBuildLabel.Text = "Offline";
            }

            try
            {
                if (File.Exists(fsoConfigFile))
                    File.Copy(fsoConfigFile, fsoConfigFile + ".backup", true);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                BlueRose.GC();
                
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(freeSODownloadCompleted);

                client.DownloadFileAsync(TeamCity.tcAddress("servo.freeso.org", "ProjectDollhouse_TsoClient"), "teamcity.zip");

                localBuild.Text = "...";

                btnUpdate.Text = "Downloading";
                btnUpdate.Enabled = false;
                devBtn.Enabled = false;
                playBtn.Enabled = false;

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                btnUpdate.Text = errorBtn;
                btnUpdate.Enabled = false;
            }
            
            
        }

        void freeSODownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {

            btnUpdate.Text = "Installing";

            TeamCity.tcUnpack();

            File.Delete(Environment.CurrentDirectory + "teamcity.zip");

            BlueRose.wildUnZip();

            BlueRose.writeBuild(buildFile);

            btnUpdate.Enabled = true;
            devBtn.Enabled = true;
            playBtn.Enabled = true;

            localBuild.Text = BlueRose.readBuild(buildFile);

            if (File.Exists(fsoConfigFile))
                File.Copy(fsoConfigFile, fsoConfigNormalBackup, true);

            if (File.Exists(fsoConfigUserBackup))
                File.Copy(fsoConfigUserBackup, fsoConfigFile, true);

            btnUpdate.Text = "Update FreeSO";

        }

        private void dwnPrgBar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdateLauncher_Click(object sender, EventArgs e)
        {
            btnUpdateLauncher.Enabled = false;

            WebClient client = new WebClient();

            client.DownloadFileCompleted += new AsyncCompletedEventHandler(brDownloadCompleted);

            client.DownloadFileAsync(BlueRose.webURL(@"https://dl.dropboxusercontent.com/u/42345729/BlueRoseUpdate.zip"),
                unpackerZip);
        }

        void brDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            btnUpdateLauncher.Text = "Unpacking";

            string unpack = unpackerZip;

            try
            {
                using (ZipArchive buildUnpack = ZipFile.OpenRead(unpack))
                {
                    foreach (ZipArchiveEntry ex in buildUnpack.Entries)
                    {
                        ex.ExtractToFile(Path.Combine(Environment.CurrentDirectory, ex.FullName), true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Process.Start("BlueRoseUpdate.exe");
            Environment.Exit(0);
        }

        private void onlineBuildLabel_Click(object sender, EventArgs e)
        {
            try
            {
                onlineBuildLabel.Text = "#" + BlueRose.distNum();
            }
            catch
            {
                onlineBuildLabel.Text = "FAILED";
            }
        }
    }
}
