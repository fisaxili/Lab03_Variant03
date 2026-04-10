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

        }
    }
}
