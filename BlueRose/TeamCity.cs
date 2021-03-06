﻿// Copyright(c) 2016 Blue Rose Project

// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
//  associated documentation files (the "Software"), to deal in the Software without restriction, including
//  without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
//  copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to 
//  the following conditions:

// The above copyright notice and this permission notice shall be included in all copies or substantial 
//  portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//  INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
//  PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
//  FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
//  ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System.IO.Compression;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace BlueRose.Distro
{
    public class TeamCity
    {
        /// <summary>
        /// Downloads and extracts teamcity.zip into the current directory.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="buildType"></param>
        /// <param name="distFile"></param>
        public static void tcManaged(string address, string buildType, string distFile = "teamcity.zip")
        {
            try
            {
                WebClient client = new WebClient();

                Uri uri = new Uri(@"http://" + address + "/guestAuth/downloadArtifacts.html?buildTypeId=" + buildType + "&buildId=lastSuccessful");
                distFile = Path.GetFileName(uri.LocalPath);

                client.DownloadFileAsync(tcAddress(address, buildType), distFile);

                using (ZipArchive buildUnpack = ZipFile.OpenRead(distFile))
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distFile"></param>
        public static void tcUnpack(string distFile = "teamcity.zip")
        {
            using (ZipArchive buildUnpack = ZipFile.OpenRead(distFile))
            {
                foreach (ZipArchiveEntry ex in buildUnpack.Entries)
                {
                    ex.ExtractToFile(Path.Combine(Environment.CurrentDirectory, ex.FullName), true);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="buildType"></param>
        /// <param name="distFile"></param>
        public static string tcDistFile(string address, string buildType, string distFile = "teamcity.zip")
        {
            try
            {
                Uri uri = new Uri(@"http://" + address + "/guestAuth/downloadArtifacts.html?buildTypeId=" + buildType + "&buildId=lastSuccessful");
                distFile = Path.GetFileName(uri.LocalPath);
                return distFile;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="buildType"></param>
        /// <returns></returns>
        public static Uri tcAddress(string address, string buildType)
        {
            try
            {
                return new Uri(@"http://" + address + "/guestAuth/downloadArtifacts.html?buildTypeId=" + buildType + "&buildId=lastSuccessful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
