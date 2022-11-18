﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using UtilitiesWpf;

namespace OnlyBindingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string YourName { get; set; }

        private string _helloMessage;
        public string HelloMessage
        {
            get { return _helloMessage; }
            set
            {
                _helloMessage = value;
                OnPropertyChanged(nameof(HelloMessage));
            }
        }

        private ICommand _mycommandClick;
        public ICommand MyCommandClick
        {
            get
            {
                /*if (_mycommandClick == null)
                    _mycommandClick = new RelayCommand<Object>(ShowMessage, EnableButton);*/
                if (_mycommandClick == null)
                {
                    _mycommandClick = new RelayCommand<Object>(
                       (Object o) =>
                       {
                           HelloMessage = $"Witaj {YourName} w tej aplikacji";
                       },
                       (Object o) => /*return*/ !string.IsNullOrWhiteSpace(YourName)
                    );
                }
                return _mycommandClick;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HelloMessage = $"Witaj {YourName} w tej aplikacji";
        }
        */
        private void ShowMessage(Object o)
        {
             HelloMessage = $"Witaj {YourName} w tej aplikacji";
        }

        private bool EnableButton(Object o)
        {
            return !string.IsNullOrWhiteSpace(YourName);
        }


    }
}