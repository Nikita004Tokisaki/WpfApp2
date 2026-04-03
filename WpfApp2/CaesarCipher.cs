using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public static class CaesarCipher
    {
        public static string Encrypt(string input, int shift)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            return ShiftText(input, shift);
        }

        public static string Decrypt(string input, int shift)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            return ShiftText(input, -shift);
        }

        private static string ShiftText(string text, int shift)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in text)
            {
                // Английский алфавит
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        result.Append((char)('A' + (mod((c - 'A') + shift, 26))));
                    }
                    else
                    {
                        result.Append((char)('a' + (mod((c - 'a') + shift, 26))));
                    }
                }
                // Русский алфавит
                else if (IsRussianLetter(c))
                {
                    bool isUpper = char.IsUpper(c);
                    int index = RussianLetterIndex(c);
                    int shiftedIndex = mod(index + shift, 33);
                    char shiftedChar = RussianLetterAt(shiftedIndex, isUpper);
                    result.Append(shiftedChar);
                }
                // Цифры
                else if (char.IsDigit(c))
                {
                    int digit = c - '0';
                    int shiftedDigit = mod(digit + shift, 10);
                    result.Append((char)('0' + shiftedDigit));
                }
                else
                {
                    // Остальные символы без изменений
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        private static int mod(int a, int b)
        {
            int r = a % b;
            return r < 0 ? r + b : r;
        }

        private static bool IsRussianLetter(char c)
        {
            // Диапазоны русских букв: А-Я, а-я
            return (c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == 'Ё' || c == 'ё';
        }

        private static int RussianLetterIndex(char c)
        {
            // Индексы для русского алфавита (учитывая Ё/ё)
            string upperLetters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string lowerLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            if (c == 'Ё') return 6; // Ё - 6-й в алфавите (учитываем, что Ё идет после Е)
            if (c == 'ё') return 6;

            if (char.IsUpper(c))
            {
                int index = upperLetters.IndexOf(c);
                return index;
            }
            else
            {
                int index = lowerLetters.IndexOf(c);
                return index;
            }
        }

        private static char RussianLetterAt(int index, bool isUpper)
        {
            string upperLetters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string lowerLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            if (isUpper)
                return upperLetters[index];
            else
                return lowerLetters[index];
        }
    }
}