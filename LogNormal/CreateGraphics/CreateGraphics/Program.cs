using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreateGraphics.BL;

namespace CreateGraphics
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Graphic graphic = new Graphic();
            MessageService messageService = new MessageService();
            FileManager fileManager = new FileManager();

            MainPresenter mainPresenter = new MainPresenter(graphic, fileManager,messageService);

            Application.Run(graphic);
        }
    }
}
