using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_Variant03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Запуск вычислений для одного значения n
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtN.Text, out int n) || n < 1 || n > 20)
            {
                MessageBox.Show("Введите целое число от 1 до 20.", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Рекурсивный ---
            var swRec = Stopwatch.StartNew();
            long resRec = Logic.FactorialRecursive(n);
            swRec.Stop();
            long callsRec = Logic.RecursiveCallCount;

            // --- Итеративный ---
            var swIter = Stopwatch.StartNew();
            long resIter = Logic.FactorialIterative(n);
            swIter.Stop();
            long opsIter = Logic.IterativeOpCount;

            lblResultRec.Text = $"Результат: {resRec}";
            lblTimeRec.Text = $"Время: {swRec.Elapsed.TotalMilliseconds:F4} мс";
            lblOpsRec.Text = $"Вызовов функции: {callsRec}";

            lblResultIter.Text = $"Результат: {resIter}";
            lblTimeIter.Text = $"Время: {swIter.Elapsed.TotalMilliseconds:F4} мс";
            lblOpsIter.Text = $"Итераций: {opsIter}";
        }

        // Экспериментальное исследование: запуск на n = 1..20
        private void btnExperiment_Click(object sender, EventArgs e)
        {
            var sizes = new List<int>();
            var timesR = new List<double>();
            var timesI = new List<double>();

            listViewResults.Items.Clear();

            for (int n = 1; n <= 20; n++)
            {
                // Среднее по 1000 запускам для точности
                const int runs = 1000;
                long totalR = 0, totalI = 0;
                long lastCallsR = 0, lastOpsI = 0;

                for (int r = 0; r < runs; r++)
                {
                    var sw = Stopwatch.StartNew();
                    Logic.FactorialRecursive(n);
                    sw.Stop();
                    totalR += sw.ElapsedTicks;
                    lastCallsR = Logic.RecursiveCallCount;

                    sw.Restart();
                    Logic.FactorialIterative(n);
                    sw.Stop();
                    totalI += sw.ElapsedTicks;
                    lastOpsI = Logic.IterativeOpCount;
                }

                double msR = (double)totalR / runs / Stopwatch.Frequency * 1000.0;
                double msI = (double)totalI / runs / Stopwatch.Frequency * 1000.0;

                sizes.Add(n);
                timesR.Add(msR);
                timesI.Add(msI);

                var item = new ListViewItem(n.ToString());
                item.SubItems.Add(msR.ToString("F6"));
                item.SubItems.Add(lastCallsR.ToString());
                item.SubItems.Add(msI.ToString("F6"));
                item.SubItems.Add(lastOpsI.ToString());
                listViewResults.Items.Add(item);
            }

            DrawChart(sizes, timesR, timesI);
        }

        private void DrawChart(List<int> sizes, List<double> timesR, List<double> timesI)
        {
            var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                int pad = 50;
                int w = bmp.Width - pad * 2;
                int h = bmp.Height - pad * 2;

                double maxT = 0;
                for (int i = 0; i < timesR.Count; i++)
                    maxT = Math.Max(maxT, Math.Max(timesR[i], timesI[i]));
                if (maxT == 0) maxT = 1;

                // Оси
                g.DrawLine(Pens.Black, pad, pad, pad, pad + h);
                g.DrawLine(Pens.Black, pad, pad + h, pad + w, pad + h);

                var font = new Font("Arial", 7);

                // Подписи оси X
                for (int i = 0; i < sizes.Count; i++)
                {
                    float x = pad + (float)i / (sizes.Count - 1) * w;
                    g.DrawString(sizes[i].ToString(), font, Brushes.Black, x - 5, pad + h + 3);
                }

                // Подписи оси Y
                for (int k = 0; k <= 4; k++)
                {
                    float y = pad + h - (float)k / 4 * h;
                    g.DrawString((maxT * k / 4).ToString("F6"), font, Brushes.Black, 0, y - 5);
                    g.DrawLine(Pens.LightGray, pad, y, pad + w, y);
                }

                // Линии графиков
                for (int i = 1; i < sizes.Count; i++)
                {
                    float x1 = pad + (float)(i - 1) / (sizes.Count - 1) * w;
                    float x2 = pad + (float)i / (sizes.Count - 1) * w;

                    float y1R = pad + h - (float)(timesR[i - 1] / maxT) * h;
                    float y2R = pad + h - (float)(timesR[i] / maxT) * h;
                    g.DrawLine(new Pen(Color.Red, 2), x1, y1R, x2, y2R);

                    float y1I = pad + h - (float)(timesI[i - 1] / maxT) * h;
                    float y2I = pad + h - (float)(timesI[i] / maxT) * h;
                    g.DrawLine(new Pen(Color.Blue, 2), x1, y1I, x2, y2I);
                }


                g.FillRectangle(Brushes.Red, pad + w - 120, pad + 5, 15, 10);
                g.DrawString("Рекурсивный", font, Brushes.Black, pad + w - 102, pad + 4);
                g.FillRectangle(Brushes.Blue, pad + w - 120, pad + 20, 15, 10);
                g.DrawString("Итеративный", font, Brushes.Black, pad + w - 102, pad + 19);

                // Подписи осей
                g.DrawString("n", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, pad + w / 2, pad + h + 18);
                g.DrawString("t (мс)", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 0, pad - 15);

                pictureBox1.Image = bmp;
            } 
        }
    }
}
