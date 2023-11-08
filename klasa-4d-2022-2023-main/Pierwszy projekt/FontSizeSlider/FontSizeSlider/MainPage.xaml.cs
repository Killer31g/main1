using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FontSizeSlider
{
    public partial class MainPage : ContentPage
    {
        int currentQuoteIndex = 0;
        string[] quotes = { "Dzień dobry", "Good morning", "Buenos dias" };

        public MainPage()
        {
            InitializeComponent();
            fontSizeSlider.Value = 0;
            fontSizeLabel.Text = "0";
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            int fontSize = (int)e.NewValue;
            fontSizeLabel.Text = fontSize.ToString();
            quoteLabel.FontSize = fontSize;
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            currentQuoteIndex = (currentQuoteIndex + 1) % quotes.Length;
            quoteLabel.Text = quotes[currentQuoteIndex];
        }
    }
}
