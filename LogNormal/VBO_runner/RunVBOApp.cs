using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;

namespace VBO_runner
{
    public class RunVBOApp
    {
        public void Generate(int countProcess, GenerateInput input, string appPath, int tryCount = 60, int waitMiliSeconds = 2000)
        {
            var oldCountProcess = countProcess;
            var getMcnpLnPath = input.autoResParentPath;
            var inputFiles = Directory.GetFiles(input.inputParentPath);
            var vboApp = new FileInfo(appPath);

            Directory.CreateDirectory(getMcnpLnPath);

            var processInfo = new ProcessStartInfo()
            {
                FileName = vboApp.Name,
                WorkingDirectory = vboApp.Directory.FullName
            };

            var listOfProcess = new List<Process>();

            var rangeOfFiles = inputFiles.Length;

            for (int j = 0; j < rangeOfFiles; j++)
            {
                processInfo.Arguments = "\"" + inputFiles[j] + "\"";
                listOfProcess.Add(Process.Start(processInfo));
                Thread.Sleep(2000);

                if ((j + 1) == countProcess)
                {
                    while (Directory.GetDirectories(getMcnpLnPath).Length != countProcess)
                    {
                        Thread.Sleep(waitMiliSeconds);
                    }
                    while (!File.Exists(Path.Combine(Directory.GetDirectories(getMcnpLnPath)[j], "mcnpIn")))
                    {
                        Thread.Sleep(waitMiliSeconds);
                    }
                    for (int i = j; i >= j + 1 - oldCountProcess; i--)
                    {
                        listOfProcess[i].Kill();
                    }
                    countProcess += oldCountProcess;
                }
            }

            //foreach (var inputFile in inputFiles)
            //{
            //    processInfo.Arguments = "\"" + inputFile + "\"";
            //    listOfProcess.Add(Process.Start(processInfo));
            //    Thread.Sleep(600);
            //}

            //bool flagStop;
            //foreach (var process in listOfProcess)
            //{
            //    flagStop = false;
            //    for (int i = 0; i < tryCount; i++)
            //    {
            //        Directory.CreateDirectory(getMcnpLnPath);
            //        foreach (var dir in Directory.GetDirectories(getMcnpLnPath))
            //        {
            //            if (File.Exists(Path.Combine(dir, "mcnpIn")))
            //            {
            //                Thread.Sleep(500);
            //                process.Kill();
            //                flagStop = true;
            //                break;
            //            }
            //        }
                    
            //        if (flagStop)
            //            break;

            //        Thread.Sleep(new TimeSpan(0, 0, waitSeconds));
            //    }
            //}

        }
    }
}