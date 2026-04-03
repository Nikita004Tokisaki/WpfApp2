using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp2; // подключаем пространство имен с классом CaesarCipher

namespace CaesarCipherTests
{
    [TestClass]
    public class CaesarCipherAutomatedTests
    {
        [TestMethod]
        public void TestEncryption_HelloShift3()
        {
            string input = "HELLO";
            int shift = 3;
            string expected = "KHOOR";

            string result = CaesarCipher.Encrypt(input, shift);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestDecryption_KHOORShift3()
        {
            string input = "KHOOR";
            int shift = 3;
            string expected = "HELLO";

            string result = CaesarCipher.Decrypt(input, shift);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestZeroShift_HelloShift0()
        {
            string input = "HELLO";
            int shift = 0;

            string result = CaesarCipher.Encrypt(input, shift);
            Assert.AreEqual("HELLO", result);
        }

        [TestMethod]
        public void TestNegativeShift_HelloMinus3()
        {
            string input = "HELLO";
            int shift = -3;
            string expected = "EBIIL";

            string result = CaesarCipher.Encrypt(input, shift);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestShiftOverAlphabet_ABC27()
        {
            string input = "ABC";
            int shift = 27; // 27 mod 26 = 1
            string expected = "BCD";

            string result = CaesarCipher.Encrypt(input, shift);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestEmptyText()
        {
            string input = "";
            int shift = 5;

            string result = CaesarCipher.Encrypt(input, shift);
            Assert.AreEqual("", result);
        }


        [TestMethod]
        public void TestLongText()
        {
            string input = new string('A', 1000);
            int shift = 10;

            string result = CaesarCipher.Encrypt(input, shift);
            Assert.AreEqual(1000, result.Length);
            Assert.AreNotEqual(input, result);
        }

        [TestMethod]
        public void TestSingleLetter()
        {
            string input = "A";
            int shift = 1;
            string expected = "B";

            string result = CaesarCipher.Encrypt(input, shift);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSymbolsAndNumbers()
        {
            string input = "HELLO!@#";
            int shift = 3;
            string expected = "KHOOR!@#";

            string result = CaesarCipher.Encrypt(input, shift);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestRussianLetters()
        {
            string input = "ПРИМЕР";
            int shift = 5;

            string result = CaesarCipher.Encrypt(input, shift);
            Assert.AreNotEqual(input, result);
        }

        [TestMethod]
        public void TestNumbersInText()
        {
            string input = "12345";
            int shift = 2;
            string expected = "34567";

            string result = CaesarCipher.Encrypt(input, shift);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestEncryptionDecryptionCycle()
        {
            string original = "HELLO";
            int shift = 4;

            string encrypted = CaesarCipher.Encrypt(original, shift);
            string decrypted = CaesarCipher.Decrypt(encrypted, shift);

            Assert.AreEqual(original, decrypted);
        }

        [TestMethod]
        public void TestSpacesAndSymbols()
        {
            string input = "HELLO WORLD!";
            int shift = 2;

            string expected = "JGNNQ YQTNF!";
            string result = CaesarCipher.Encrypt(input, shift);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLargeDataPerformance()
        {
            string largeText = new string('A', 100000);
            int shift = 5;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            string result = CaesarCipher.Encrypt(largeText, shift);
            watch.Stop();

            Assert.IsTrue(watch.ElapsedMilliseconds < 2000, "Обработка заняла слишком много времени");
            Assert.AreEqual(100000, result.Length);
        }
    }
}