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

namespace PracownikHasloApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string generatedPassword;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonGeneratedPassword_Click(object sender, RoutedEventArgs e)
        {
            byte passwordLength;
            
            if(!byte.TryParse(textboxPasswordLength.Text, out passwordLength))
            {
                MessageBox.Show("Długość hasła jest niepoprawna");
                return;
            }

            bool? isCapitalLetter = checkBoxCapitalLetter.IsChecked;
            bool? isDigit = checkBoxDigit.IsChecked;
            bool? isSpecialChar = checkBoxSpecialChar.IsChecked;

            byte minPasswordLength = 1;
            if (isCapitalLetter == true)
            {
                minPasswordLength++;
            }
            if (isDigit == true)
            {
                minPasswordLength++;
            }
            if (isSpecialChar == true)
            {
                minPasswordLength++;
            }
            if (passwordLength < minPasswordLength)
            {
                MessageBox.Show("Długość hasła jest za krótka");
                return;
            }

            string smallLettersSet = "qwertyuiopasdfghjklzxcvbnm";
            string capitalLettersSet = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string digitsSet = "1234567890";
            string specialCharsSet = "!@#$%^&*()_+-=";

            generatedPassword = string.Empty;
            Random random = new Random();
            if (isCapitalLetter == true)
            {
                char randomChar = capitalLettersSet[random.Next(0, capitalLettersSet.Length)];
                generatedPassword += randomChar;
            }
            if (isDigit == true)
            {
                char randomChar = digitsSet[random.Next(0, digitsSet.Length)];
                generatedPassword += randomChar;
            }
            if (isSpecialChar == true)
            {
                char randomChar = specialCharsSet[random.Next(0, specialCharsSet.Length)];
                generatedPassword += randomChar;
            }

            int missingNumberOfSmallLetters = passwordLength - generatedPassword.Length;
            
            for(int i = 0; i < missingNumberOfSmallLetters; i++)
            {
                char randomChar = smallLettersSet[random.Next(0, smallLettersSet.Length)];
                generatedPassword += randomChar;
            }
            
            /*generatedPassword += smallLettersSet.OrderBy(c => random.Next()).Take(missingNumberOfSmallLetters).ToString();*/

            MessageBox.Show(generatedPassword);
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            string message = "Dane pracownika: \n";

            message += "Imie i nazwisko: " + textBoxName.Text + "\n";
            message += textBoxSurname.Text + "\n";
            message += "Stanowisko: " + comboBoxJob.Text + "\n";
            message += "Hasło: " + generatedPassword;

            MessageBox.Show(message);
        }
    }
}
