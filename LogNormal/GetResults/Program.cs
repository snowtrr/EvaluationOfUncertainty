using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new ReadResults();
            var createGraph = new CreateGraphicData();
            createGraph.Create(reader.Read(Console.ReadLine()), 15);
            
            Console.ReadLine();
        }
    }
}
