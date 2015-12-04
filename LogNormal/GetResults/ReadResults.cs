namespace GetResults
{
    using System.Collections.Generic;
    using System.IO;

    public class ReadResults
    {
        public double[] Read(string path, string material)
        {
            // All folders mass
            var allFolders = Directory.GetDirectories(path);
            var listOfBurned = new List<double>();

            foreach (var folder in allFolders)
            {
                // Files if current folder
                var files = Directory.GetFiles(folder);

                foreach (var file in files)
                {
                    if (new FileInfo(file).Name == "mcnpIn")
                    {
                        var content = File.ReadAllLines(file);

                        var flagStartRead = false;
                        foreach (var line in content)
                        {
                            if (line.Contains("c materials"))
                            {
                                flagStartRead = true;
                            }
                            if (line.Contains("c end materials"))
                            {
                                flagStartRead = false;
                            }
                            if (flagStartRead)
                            {
                                if (line.Contains(material))
                                {
                                    var newLine = (line.Remove(0, 16)).Trim();
                                    listOfBurned.Add(double.Parse(newLine, System.Globalization.CultureInfo.InvariantCulture));
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return listOfBurned.ToArray();
        } 
    }
}