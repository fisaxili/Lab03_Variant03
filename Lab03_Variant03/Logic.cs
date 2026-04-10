using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_Variant03
{
    /// <summary>
    /// Вычислительное ядро: рекурсивный и итеративный факториал.
    /// </summary>
    public static class Logic
    {
        // Счётчики операций (сбрасываются перед каждым вызовом)
        public static long RecursiveCallCount { get; private set; }
        public static long IterativeOpCount { get; private set; }

        /// <summary>
        /// Рекурсивное вычисление факториала n!
        /// Сложность: O(n) по времени, O(n) по памяти (стек вызовов)
        /// </summary>
        public static long FactorialRecursive(int n)
        {
            if (n < 0) throw new ArgumentException("n не может быть отрицательным");
            if (n > 20) throw new ArgumentException("n не должно превышать 20");
            RecursiveCallCount = 0;
            return RecursiveHelper(n);
        }

        private static long RecursiveHelper(int n)
        {
            RecursiveCallCount++; // считаем каждый вызов функции
            if (n == 0 || n == 1) return 1;
            return n * RecursiveHelper(n - 1);
        }

    }
