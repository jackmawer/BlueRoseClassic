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
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO.Compression;
using System.Net;

namespace BlueRoseApp
{
    public class BlueRose
    {

        public static string[] fsoParmas { get; set; }

        public static Uri teamCityUri(string address, string buildType)
        {
            return new Uri(@"http://" + address + "/guestAuth/downloadArtifacts.html?buildTypeId=" + buildType + "&buildId=lastSuccessful");
        }

        /// <summary>
        /// Returns a given URL. If it isn't there,
        /// defualt to Google.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>new Uri(url);</returns>
        public static Uri webPage(string url)
        {
            try
            {
                return new Uri(url);
            }
            catch
            {
                return new Uri("https://google.com");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns>new Uri(url);</returns>
        public static Uri webURL(string url)
        {
            try
            {
                return new Uri(url);
            }
            catch
            {
                return new Uri(null);
            }
        }

        /// <summary>
        /// If FreeSO isn't found, alert the user.
        /// If OpenAL isn't installed, show downloads address.
        /// </summary>
        /// <param name="fso"></param>
        public static void StartFSO(string fso)
        {
            
            try
            {
                Process fsoProcess = new Process();

                fsoProcess.StartInfo.FileName = fso;
                fsoProcess.StartInfo.UseShellExecute = true;
                fsoProcess.Start();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, fso);
            }
            

        }

        /// <summary>
        /// Return the latest dist number as a string
        /// Thanks to LRB. http://forum.freeso.org/threads/974/
        /// </summary>
        /// <returns>sLine</returns>
        public static string distNum()
        {
            string url = "http://servo.freeso.org/externalStatus.html?js=1";
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(url);
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);
            string sLine = "";
            string fll;
            fll = objReader.ReadLine();
            sLine = fll.Remove(0, 855);
            sLine = sLine.Remove(sLine.IndexOf("</a>"));
            return sLine;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string readBuild(string file)
        {
            string line;

            try
            {
                string buildFile = Environment.CurrentDirectory + @"/" + file;
                StreamReader fileRead = new StreamReader(buildFile);
                while ((line = fileRead.ReadLine()) != null)
                {
                    return "#" + line;
                }

                fileRead.Close();
            }
            catch
            {
                return "NONE";
            }

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public static void writeBuild(string file)
        {
            string buildFile = Environment.CurrentDirectory + @"/" + file;
            string localDist = distNum();

            try
            {
                File.WriteAllText(buildFile, localDist);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cleans up downloaded files.
        /// </summary>
        public static void GC()
        {
            string htmlOutput = "downloadArtifacts.html"; // Legacy
            string brLegacyInstaller = "BlueRoseStable.exe";
            string brUpdateInstaller = "BlueRoseUpdate.exe";

            if (File.Exists(brLegacyInstaller) || File.Exists(brUpdateInstaller) || File.Exists(htmlOutput))
            {
                File.Delete(brLegacyInstaller);
                File.Delete(brUpdateInstaller);
                File.Delete(htmlOutput);
            }

            Wildcard wildZip = new Wildcard("*.zip", RegexOptions.IgnoreCase);
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);

            foreach(string file in files)
            {
                if (wildZip.IsMatch(file))
                {
                    File.Delete(file);
                }
            }
        }

        /// <summary>
        /// Detects for any present zips and unpacks them.
        /// </summary>
        public static void wildUnZip()
        {
            Wildcard unpacker = new Wildcard("*.zip", RegexOptions.IgnoreCase);

            // Get a list of files in the current directory
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);

            try
            {
                foreach (string file in files)
                {
                    if (unpacker.IsMatch(file))
                    {
                        using (ZipArchive zip2 = ZipFile.OpenRead(file))
                        {
                            foreach (ZipArchiveEntry ex in zip2.Entries)
                            {
                                ex.ExtractToFile(Path.Combine(Environment.CurrentDirectory, ex.FullName), true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
