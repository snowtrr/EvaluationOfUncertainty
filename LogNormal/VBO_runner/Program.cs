using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBO_runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var genInp = new GenerateInput();
            var runVBOApp = new RunVBOApp();

            if(genInp.Generate(Console.ReadLine(), Console.ReadLine()))
            runVBOApp.Generate(4, genInp, Console.ReadLine());
        }
    }
}
