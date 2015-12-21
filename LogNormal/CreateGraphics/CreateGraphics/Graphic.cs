using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateGraphics
{
    public interface IGraphic
    {
        string FilePath { get; }
        double[] ContentX { get; set; }
        double[] ContentY { get; set; }

        event EventHandler FileOpenClick;
    }

     public partial class Graphic : Form, IGraphic
    {
        public double[] ContentX { get; set; }
        public double[] ContentY { get; set; }

        public Graphic()
        {
            InitializeComponent();
            butOpen.Click += ButOpen_Click;
        }

        private void ButOpen_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "All files|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fldFilePath.Text = dlg.FileName;

                if (FileOpenClick != null)
                {
                    FileOpenClick(this, EventArgs.Empty);
                }
                
                for (int i = 0; i < ContentX.Length; i++)
                {
                    graphicChart.Series[0].Points.AddXY(ContentX[i], ContentY[i]);
                }
            }
        }

        #region IMainForm realization
        public string FilePath
        {
            get { return fldFilePath.Text; }
        }
        
        public event EventHandler FileOpenClick;
        #endregion IMainForm realization
    }
}
