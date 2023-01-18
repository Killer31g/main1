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

namespace INF0._4styczeń_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string password;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonGeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            string smallLetters = "abcdefghijklmnopqrstuvwxyz";
            string bigLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digit = "01233456789";
            string specialChar = @"!@#$%^&*()-_=+[]{}\/|:;<>,.?~`'";

            //int passwordLength = textBoxPasswordLength.Text;
            if (!int.TryParse(textBoxPasswordLength.Text, out int passwordLength))
            {
                MessageBox.Show("Nieprawidłowa wartość długości hasła");
                return;
            }

            bool hasBigLetters = checkBoxHasLetters.IsChecked.Value;
            bool hasDigit = checkBoxHasDigit.IsChecked.Value;
            bool hasSpecialChar = checkBoxHasSpecialChar.IsChecked.Value;

            password = "";
            Random random = new Random();

            //wersja 1
            if (hasBigLetters)
            {
                password += bigLetters[random.Next(bigLetters.Length)];
            }
            if (hasDigit)
            {
                password += digit[random.Next(digit.Length)];
            }
            if (hasSpecialChar)
            {
                password += specialChar[random.Next(specialChar.Length)];
            }
            for (int i = passwordLength; i < passwordLength; i++) 
            { 
                password += smallLetters[random.Next(smallLetters.Length)];
            }
            MessageBox.Show(password);
        }
    }
}
