using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace BlueRoseApp
{
    public partial class ConfigGame : Form
    {
        string fsoConfigFile = Environment.CurrentDirectory + @"\FreeSO.exe.config";
        string fsoConfigNormalBackup = Environment.CurrentDirectory + @"\FreeSO.exe.config.backup";
        string fsoConfigUserBackup = Environment.CurrentDirectory + @"\FreeSO.exe.config.userbackup";
        string winSet = "true";
        string errorMsg = "ERROR";
        string settingsSavedMsg = "Settings saved.";
        string heightRes { get; set; }
        string widthRes { get; set; }


        public ConfigGame()
        {
            
            try
            {
                InitializeComponent();

                this.MaximizeBox = false;
                this.MinimizeBox = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setResConfig(string height, string width)
        {
            try
            {
                if (File.Exists(fsoConfigFile))
                {
                    File.Copy(fsoConfigFile, fsoConfigNormalBackup, true);

                    string[] lines = File.ReadAllLines(fsoConfigFile);
                    lines[71] = "                <value>" + width + "</value>";
                    lines[74] = "                <value>" + height + "</value>";
                    File.WriteAllLines(fsoConfigFile, lines);

                    if (File.Exists(fsoConfigFile))
                        File.Copy(fsoConfigFile, fsoConfigUserBackup, true);

                    configStatus.Text = settingsSavedMsg;
                }
            }
            catch
            {
                configStatus.Text = errorMsg;

                if (File.Exists(fsoConfigNormalBackup))
                    File.Copy(fsoConfigNormalBackup, fsoConfigFile, true);

            }
        }

        private void ConfigGame_Load(object sender, EventArgs e)
        {
            try
            {
                string[] lines = File.ReadAllLines(fsoConfigFile);

                widthRes = lines[71].Replace("                <value>", "").Replace("</value>", "");
                heightRes = lines[74].Replace("                <value>", "").Replace("</value>", "");

                heightTextBox.Text = heightRes;
                widthTextBox.Text = widthRes;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setRes_Click(object sender, EventArgs e)
        {
            setResConfig(heightTextBox.Text, widthTextBox.Text);

            setRes.Text = "Resolution Saved";

            
        }
    }
}
