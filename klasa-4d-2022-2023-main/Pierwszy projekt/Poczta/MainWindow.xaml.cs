using System;
using System.Windows;
using System.Windows.Controls;

namespace PocztaApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SprawdzCeneButton_Click(object sender, RoutedEventArgs e)
        {
            string wybranaOpcja = WybranaOpcja();
            CenaLabel.Content = $"Cena: {ObliczCene(wybranaOpcja)} zł";
            CenaLabel.Visibility = Visibility.Visible;
            MessageBox.Show($"Wybrano opcję: {wybranaOpcja}");
        }

        private string WybranaOpcja()
        {
            if (PocztowkaRadioButton.IsChecked == true)
                return "Pocztówka";
            if (ListRadioButton.IsChecked == true)
                return "List";
            if (PaczkaRadioButton.IsChecked == true)
                return "Paczka";
            return string.Empty;
        }

        private decimal ObliczCene(string opcja)
        {
            switch (opcja)
            {
                case "Pocztówka":
                    return 1.0m;
                case "List":
                    return 1.5m;
                case "Paczka":
                    return 10.0m;
                default:
                    return 0.0m;
            }
        }

        private void ZatwierdzButton_Click(object sender, RoutedEventArgs e)
        {
            string kodPocztowy = KodPocztowyTextBox.Text;

            if (SprawdzKodPocztowy(kodPocztowy))
            {
                MessageBox.Show("Dane przesyłki zostały wprowadzone");
            }
        }

        private bool SprawdzKodPocztowy(string kod)
        {
            if (!CzyLiczby(kod))
            {
                MessageBox.Show("Kod pocztowy powinien się składać z samych cyfr");
                return false;
            }
            if (kod.Length != 5)
            {
                MessageBox.Show("Nieprawidłowa liczba cyfr w kodzie pocztowym");
                return false;
            }
            return true;
        }

        private bool CzyLiczby(string tekst)
        {
            foreach (char c in tekst)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
