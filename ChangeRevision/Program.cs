﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ChangeRevision
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //const string GIT = "\"c:\\Program Files (x86)\\Git\\cmd\\git.exe\"";
                const string GIT64 = "\"c:\\Program Files\\Git\\cmd\\git.exe\"";

                //string git;
                //if (args[3] == "32")
                //{
                //    git = GIT;
                //}
                //else
                //{
                //    git = GIT64;
                //}
                Process process = new Process();
                process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                process.StartInfo.FileName = GIT64;                
                process.StartInfo.Arguments = @"rev-list master --count";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                StringBuilder output = new StringBuilder();
                int timeout = 10000;

                using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
                using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
                {
                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (e.Data == null)
                            outputWaitHandle.Set();
                        else
                            output.AppendLine(e.Data);
                    };

                    process.Start();
                    process.BeginOutputReadLine();

                    if (process.WaitForExit(timeout) && outputWaitHandle.WaitOne(timeout))
                    {
                        string text = File.ReadAllText(@"..\..\..\" + args[1] + @"\Properties\AssemblyInfo.cs");

                        Match match = new Regex("AssemblyVersion\\(\"(.*?)\"\\)").Match(text);
                        Version ver = new Version(match.Groups[1].Value);
                        int build = args[0] == "Release" ? ver.Build + 1 : ver.Build;
                        Version newVer = new Version(ver.Major, ver.Minor, build, Convert.ToInt16(output.ToString().Trim()));

                        text = Regex.Replace(text, @"AssemblyVersion\((.*?)\)", "AssemblyVersion(\"" + newVer.ToString() + "\")");
                        text = Regex.Replace(text, @"AssemblyFileVersionAttribute\((.*?)\)", "AssemblyFileVersionAttribute(\"" + newVer.ToString() + "\")");
                        text = Regex.Replace(text, @"AssemblyFileVersion\((.*?)\)", "AssemblyFileVersion(\"" + newVer.ToString() + "\")");

                        File.WriteAllText(@"..\..\..\" + args[1] + @"\Properties\AssemblyInfo.cs", text);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
            }

        }
    }
}