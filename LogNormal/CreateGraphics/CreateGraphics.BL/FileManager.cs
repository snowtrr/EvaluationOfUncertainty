namespace CreateGraphics.BL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;

    public interface IFileManager
    {
        bool IsExist(string filePath);
        void ReadContent(string filePath);
        void ReadContent(string filePath, Encoding encoding);
        double[] GetContentX { get; }
        double[] GetContentY { get; }

    }

    /// <summary>
    /// Read file Manager
    /// </summary>
    public class FileManager : IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);
        List<double> listX = new List<double>();
        List<double> listY = new List<double>();

        public double[] GetContentX { get { return listX.ToArray(); } }

        public double[] GetContentY { get { return listY.ToArray(); } }

        /// <summary>
        /// Check existing file
        /// </summary>
        /// <param name="filePath">filePath</param>
        /// <returns></returns>
        public bool IsExist(string filePath)
        {
            bool exist = File.Exists(filePath);
            return exist;
        }

        public void ReadContent(string filePath)
        {
            ReadContent(filePath, _defaultEncoding);
        }
        
        public void ReadContent(string filePath, Encoding encoding)
        {
            string[] content = File.ReadAllLines(filePath, encoding);
            
            foreach (var line in content)
            {
                var xy = line.Split(' ');
                
                listX.Add(double.Parse(xy[0]));
                listY.Add(double.Parse(xy[1]));
            }
        }
     }
}