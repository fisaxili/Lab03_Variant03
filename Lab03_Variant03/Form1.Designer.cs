namespace Lab03_Variant03
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtN = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnExperiment = new System.Windows.Forms.Button();
            this.lblResultRec = new System.Windows.Forms.Label();
            this.lblTimeRec = new System.Windows.Forms.Label();
            this.lblOpsRec = new System.Windows.Forms.Label();
            this.lblResultIter = new System.Windows.Forms.Label();
            this.lblTimeIter = new System.Windows.Forms.Label();
            this.lblOpsIter = new System.Windows.Forms.Label();
            this.groupRec = new System.Windows.Forms.GroupBox();
            this.groupIter = new System.Windows.Forms.GroupBox();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.colN = new System.Windows.Forms.ColumnHeader();
            this.colTimeR = new System.Windows.Forms.ColumnHeader();
            this.colOpsR = new System.Windows.Forms.ColumnHeader();
            this.colTimeI = new System.Windows.Forms.ColumnHeader();
            this.colOpsI = new System.Windows.Forms.ColumnHeader();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblN = new System.Windows.Forms.Label();
            this.groupRec.SuspendLayout();
            this.groupIter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();

            // lblN
            this.lblN.Text = "Введите n (1–20):";
            this.lblN.Location = new System.Drawing.Point(12, 15);
            this.lblN.Size = new System.Drawing.Size(120, 20);

            // txtN
            this.txtN.Location = new System.Drawing.Point(138, 12);
            this.txtN.Size = new System.Drawing.Size(60, 23);

            // btnCalculate
            this.btnCalculate.Text = "Вычислить";
            this.btnCalculate.Location = new System.Drawing.Point(210, 11);
            this.btnCalculate.Size = new System.Drawing.Size(100, 25);
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            // btnExperiment
            this.btnExperiment.Text = "Эксперимент (n=1..20)";
            this.btnExperiment.Location = new System.Drawing.Point(320, 11);
            this.btnExperiment.Size = new System.Drawing.Size(180, 25);
            this.btnExperiment.Click += new System.EventHandler(this.btnExperiment_Click);

            // groupRec
            this.groupRec.Text = "Рекурсивный метод";
            this.groupRec.Location = new System.Drawing.Point(12, 45);
            this.groupRec.Size = new System.Drawing.Size(240, 90);
            this.lblResultRec.Location = new System.Drawing.Point(8, 20);
            this.lblResultRec.Size = new System.Drawing.Size(220, 20);
            this.lblResultRec.Text = "Результат: —";
            this.lblTimeRec.Location = new System.Drawing.Point(8, 42);
            this.lblTimeRec.Size = new System.Drawing.Size(220, 20);
            this.lblTimeRec.Text = "Время: —";
            this.lblOpsRec.Location = new System.Drawing.Point(8, 64);
            this.lblOpsRec.Size = new System.Drawing.Size(220, 20);
            this.lblOpsRec.Text = "Вызовов функции: —";
            this.groupRec.Controls.Add(this.lblResultRec);
            this.groupRec.Controls.Add(this.lblTimeRec);
            this.groupRec.Controls.Add(this.lblOpsRec);

            // groupIter
            this.groupIter.Text = "Итеративный метод";
            this.groupIter.Location = new System.Drawing.Point(265, 45);
            this.groupIter.Size = new System.Drawing.Size(240, 90);
            this.lblResultIter.Location = new System.Drawing.Point(8, 20);
            this.lblResultIter.Size = new System.Drawing.Size(220, 20);
            this.lblResultIter.Text = "Результат: —";
            this.lblTimeIter.Location = new System.Drawing.Point(8, 42);
            this.lblTimeIter.Size = new System.Drawing.Size(220, 20);
            this.lblTimeIter.Text = "Время: —";
            this.lblOpsIter.Location = new System.Drawing.Point(8, 64);
            this.lblOpsIter.Size = new System.Drawing.Size(220, 20);
            this.lblOpsIter.Text = "Итераций: —";
            this.groupIter.Controls.Add(this.lblResultIter);
            this.groupIter.Controls.Add(this.lblTimeIter);
            this.groupIter.Controls.Add(this.lblOpsIter);

            // listViewResults
            this.listViewResults.Location = new System.Drawing.Point(12, 145);
            this.listViewResults.Size = new System.Drawing.Size(760, 150);
            this.listViewResults.View = System.Windows.Forms.View.Details;
            this.listViewResults.FullRowSelect = true;
            this.listViewResults.GridLines = true;
            this.colN.Text = "n"; this.colN.Width = 40;
            this.colTimeR.Text = "Рек. время (мс)"; this.colTimeR.Width = 140;
            this.colOpsR.Text = "Рек. вызовов"; this.colOpsR.Width = 120;
            this.colTimeI.Text = "Ит. время (мс)"; this.colTimeI.Width = 140;
            this.colOpsI.Text = "Ит. итераций"; this.colOpsI.Width = 120;
            this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colN, this.colTimeR, this.colOpsR, this.colTimeI, this.colOpsI });

            // pictureBox1
            this.pictureBox1.Location = new System.Drawing.Point(12, 305);
            this.pictureBox1.Size = new System.Drawing.Size(760, 250);
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Form1
            this.ClientSize = new System.Drawing.Size(790, 570);
            this.Text = "Лабораторная работа №3 — Факториал (Вариант 3)";
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnExperiment);
            this.Controls.Add(this.groupRec);
            this.Controls.Add(this.groupIter);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.pictureBox1);

            this.groupRec.ResumeLayout(false);
            this.groupIter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnExperiment;
        private System.Windows.Forms.Label lblResultRec;
        private System.Windows.Forms.Label lblTimeRec;
        private System.Windows.Forms.Label lblOpsRec;
        private System.Windows.Forms.Label lblResultIter;
        private System.Windows.Forms.Label lblTimeIter;
        private System.Windows.Forms.Label lblOpsIter;
        private System.Windows.Forms.GroupBox groupRec;
        private System.Windows.Forms.GroupBox groupIter;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.ColumnHeader colN;
        private System.Windows.Forms.ColumnHeader colTimeR;
        private System.Windows.Forms.ColumnHeader colOpsR;
        private System.Windows.Forms.ColumnHeader colTimeI;
        private System.Windows.Forms.ColumnHeader colOpsI;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblN;
    }
}
