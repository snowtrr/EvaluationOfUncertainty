namespace CreateGraphics
{
    partial class Graphic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.fldFilePath = new System.Windows.Forms.TextBox();
            this.graphicChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.butOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graphicChart)).BeginInit();
            this.SuspendLayout();
            // 
            // fldFilePath
            // 
            this.fldFilePath.Location = new System.Drawing.Point(12, 12);
            this.fldFilePath.Name = "fldFilePath";
            this.fldFilePath.ReadOnly = true;
            this.fldFilePath.Size = new System.Drawing.Size(398, 22);
            this.fldFilePath.TabIndex = 0;
            this.fldFilePath.Text = "Выберите расположение файла";
            // 
            // graphicChart
            // 
            this.graphicChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.graphicChart.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.graphicChart.Legends.Add(legend3);
            this.graphicChart.Location = new System.Drawing.Point(12, 46);
            this.graphicChart.Name = "graphicChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.graphicChart.Series.Add(series3);
            this.graphicChart.Size = new System.Drawing.Size(678, 557);
            this.graphicChart.TabIndex = 1;
            this.graphicChart.Text = "chart1";
            // 
            // butOpen
            // 
            this.butOpen.Location = new System.Drawing.Point(416, 6);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(274, 34);
            this.butOpen.TabIndex = 2;
            this.butOpen.Text = "Выбрать файл и построить график";
            this.butOpen.UseVisualStyleBackColor = true;
            // 
            // Graphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 619);
            this.Controls.Add(this.butOpen);
            this.Controls.Add(this.graphicChart);
            this.Controls.Add(this.fldFilePath);
            this.Name = "Graphic";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.graphicChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fldFilePath;
        private System.Windows.Forms.DataVisualization.Charting.Chart graphicChart;
        private System.Windows.Forms.Button butOpen;
    }
}

