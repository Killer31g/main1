﻿using FirstMVVMApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilitiesWpf;

namespace FirstMVVMApp.ViewModel
{
    class ActionVM: ObserverVM
    {
        private Data data = new Data();

        public string NumberProp
        {
            set
            {
                data.Number = value;
                OnPropertyChanged(nameof(NumberProp));
            }
            get
            {
                return data.Number;
            }
        }

        private string _resultMessage;

        public string ResultMessage
        {
            get 
            { 
                return _resultMessage; 
            }
            set 
            { 
                _resultMessage = value;
                OnPropertyChanged(nameof(ResultMessage));
            }
        }

        private ICommand _commandCalculate;

        public ICommand CommandCalculate
        {
            get 
            { 
                if (_commandCalculate == null)
                {
                    _commandCalculate = new RelayCommand<Object>(
                        (Object o) =>
                        {
                            if (int.TryParse(NumberProp, out int number))
                                ResultMessage = $"Wynik {NumberProp} * {NumberProp} = {number * number}";
                            else
                                ResultMessage = "Podano nie liczbę";
                        }
                        );
                }
                return _commandCalculate; 
            }
        }



    }
}
