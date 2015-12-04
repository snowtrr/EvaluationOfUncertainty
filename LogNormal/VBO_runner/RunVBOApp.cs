namespace VBO_runner
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;

    public class RunVboApp
    {
        public void Generate(int countProcess, GenerateInput input, string appPath, int tryCount = 60, int waitMiliSeconds = 2000)
        {
            var oldCountProcess = countProcess;
            var getMcnpLnPath = input.AutoResParentPath;
            var inputFiles = Directory.GetFiles(input.InputParentPath);
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
        }
    }
}