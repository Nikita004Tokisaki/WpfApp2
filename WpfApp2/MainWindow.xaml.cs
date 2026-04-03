using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnExecuteClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string inputText = InputTextBox.Text;
                string shiftStr = ShiftTextBox.Text;

                if (string.IsNullOrWhiteSpace(inputText))
                {
                    MessageBox.Show("Введите текст для обработки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!int.TryParse(shiftStr, out int shift))
                {
                    MessageBox.Show("Пожалуйста, введите целое число для сдвига.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                bool isEncryption = EncryptRadio.IsChecked == true;
                string output;

                if (isEncryption)
                {
                    output = CaesarCipher.Encrypt(inputText, shift);
                }
                else
                {
                    output = CaesarCipher.Decrypt(inputText, shift);
                }

                ResultTextBox.Text = output;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
