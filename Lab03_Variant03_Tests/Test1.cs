
using Lab03_Variant03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab03_Variant03_Tests
{
    [TestClass]
    public class Test1
    {
        // ─── Рекурсивный метод ───────────────────────────────────────────────

        /// <summary>Типичный случай: 5! = 120</summary>
        [TestMethod]
        public void Recursive_Typical_5()
        {
            Assert.AreEqual(120L, Logic.FactorialRecursive(5));
        }

        /// <summary>Граничный случай: 1! = 1</summary>
        [TestMethod]
        public void Recursive_Boundary_1()
        {
            Assert.AreEqual(1L, Logic.FactorialRecursive(1));
        }

        /// <summary>Граничный случай: 0! = 1</summary>
        [TestMethod]
        public void Recursive_Boundary_0()
        {
            Assert.AreEqual(1L, Logic.FactorialRecursive(0));
        }

        /// <summary>Максимальное допустимое значение: 20! = 2432902008176640000</summary>
        [TestMethod]
        public void Recursive_Max_20()
        {
            Assert.AreEqual(2432902008176640000L, Logic.FactorialRecursive(20));
        }

        /// <summary>Некорректный ввод: отрицательное число — ожидается исключение</summary>
        [TestMethod]
        public void Recursive_Negative_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentException>(() => Logic.FactorialRecursive(-1));
        }

        /// <summary>Некорректный ввод: n > 20 — ожидается исключение</summary>
        [TestMethod]
        public void Recursive_TooLarge_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentException>(() => Logic.FactorialRecursive(21));
        }

        /// <summary>Счётчик вызовов для n=5 должен быть равен 5</summary>
        [TestMethod]
        public void Recursive_CallCount_5()
        {
            Logic.FactorialRecursive(5);
            Assert.AreEqual(5L, Logic.RecursiveCallCount);
        }

        // ─── Итеративный метод ───────────────────────────────────────────────

        /// <summary>Типичный случай: 5! = 120</summary>
        [TestMethod]
        public void Iterative_Typical_5()
        {
            Assert.AreEqual(120L, Logic.FactorialIterative(5));
        }

        /// <summary>Граничный случай: 1! = 1</summary>
        [TestMethod]
        public void Iterative_Boundary_1()
        {
            Assert.AreEqual(1L, Logic.FactorialIterative(1));
        }

        /// <summary>Граничный случай: 0! = 1</summary>
        [TestMethod]
        public void Iterative_Boundary_0()
        {
            Assert.AreEqual(1L, Logic.FactorialIterative(0));
        }

        /// <summary>Максимальное допустимое значение: 20!</summary>
        [TestMethod]
        public void Iterative_Max_20()
        {
            Assert.AreEqual(2432902008176640000L, Logic.FactorialIterative(20));
        }

        /// <summary>Некорректный ввод: отрицательное число — ожидается исключение</summary>
        [TestMethod]
        public void Iterative_Negative_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentException>(() => Logic.FactorialIterative(-1));
        }

        /// <summary>Некорректный ввод: n > 20 — ожидается исключение</summary>
        [TestMethod]
        public void Iterative_TooLarge_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentException>(() => Logic.FactorialIterative(21));
        }

        /// <summary>Счётчик итераций для n=5 должен быть равен 4 (цикл от 2 до 5)</summary>
        [TestMethod]
        public void Iterative_OpCount_5()
        {
            Logic.FactorialIterative(5);
            Assert.AreEqual(4L, Logic.IterativeOpCount);
        }

        // ─── Сравнение результатов ───────────────────────────────────────────

        /// <summary>Оба метода дают одинаковый результат для всех n от 1 до 20</summary>
        [TestMethod]
        public void BothMethods_SameResult_AllValues()
        {
            for (int n = 1; n <= 20; n++)
                Assert.AreEqual(Logic.FactorialRecursive(n), Logic.FactorialIterative(n),
                    $"Расхождение при n={n}");
        }

        /// <summary>Проверка конкретных значений: 10! = 3628800</summary>
        [TestMethod]
        public void Both_KnownValue_10()
        {
            Assert.AreEqual(3628800L, Logic.FactorialRecursive(10));
            Assert.AreEqual(3628800L, Logic.FactorialIterative(10));
        }
    }
}
