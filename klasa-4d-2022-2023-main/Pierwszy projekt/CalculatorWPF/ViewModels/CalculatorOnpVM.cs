using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilitiesWpf;

namespace CalculatorWPF.ViewModels
{
    class CalculatorOnpVM : ObserverVM
    {
        private bool canExecuteArithmeticOperationCommandFlag = false;

        private string _showValue;

        public string ShowValue
        {
            get
            {
                return _showValue;
            }
            set
            {
                _showValue = value;
                OnPropertyChanged(nameof(ShowValue));
            }
        }

        private ICommand _numberCommand;

        public ICommand NumberCommand
        {
            get
            {
                if (_numberCommand == null)
                    _numberCommand = new RelayCommand<object>(
                        (object o) =>
                        {
                            ShowValue += o.ToString();
                            canExecuteArithmeticOperationCommandFlag = true;
                        });
                return _numberCommand;
            }
        }

        private ICommand _arithmeticOperationsCommand;

        public ICommand ArithmeticOperationsCommand
        {
            get
            {
                if (_arithmeticOperationsCommand == null)
                    _arithmeticOperationsCommand = new RelayCommand<object>(
                        (object o) =>
                        {
                            ShowValue += " " + o.ToString() + " ";
                        });
                return _arithmeticOperationsCommand;
            }
        }

        private ICommand _equalCommand;

        public ICommand EqualCommand
        {
            get
            {
                if (_equalCommand == null)
                    _equalCommand = new RelayCommand<object>(
                        (object o) =>
                        {
                            string onpStr = GenerateOnp(ShowValue);

                            ShowValue = CalculateOnp(onpStr);
                        });
                return _equalCommand;
            }
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                    _clearCommand = new RelayCommand<object>(
                        (object o) =>
                        {
                            ShowValue = "";
                            canExecuteArithmeticOperationCommandFlag = false;
                        });
                return _clearCommand;
            }

        }

        private ICommand _backCommand;
        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                    _backCommand = new RelayCommand<object>(
                        (object o) =>
                        {
                            if (string.IsNullOrEmpty(ShowValue))
                            {
                                return;
                            }

                            if (canExecuteArithmeticOperationCommandFlag)
                            {
                                //trzy znaki
                                ShowValue = ShowValue.Remove(ShowValue.Length - 3, 3);
                            }
                            else
                            {
                                //jeden znak
                                ShowValue = ShowValue.Remove(ShowValue.Length - 1, 1);
                            }

                            if (string.IsNullOrEmpty(ShowValue) || ShowValue[^1] == ' ')
                                canExecuteArithmeticOperationCommandFlag = false;
                            else
                                canExecuteArithmeticOperationCommandFlag = true;
                        });
                return _backCommand;
            }

        }

        private ICommand _keyDownCommand;
        public ICommand KeyDownCommand
        {
            get
            {
                if (_keyDownCommand == null)
                    _keyDownCommand = new RelayCommand<object>(
                        (object o) =>
                        {
                            KeyEventArgs eventArgs = o as KeyEventArgs;
                            if (eventArgs is not null)
                            {
                                if (eventArgs.Key >= Key.NumPad0 && eventArgs.Key <= Key.NumPad9)
                                    NumberCommand.Execute(((int)eventArgs.Key - 74).ToString());
                                if (eventArgs.KeyboardDevice.Modifiers == ModifierKeys.None
                                && eventArgs.Key >= Key.D0
                                && eventArgs.Key <= Key.D9)
                                    NumberCommand.Execute(((int)eventArgs.Key - 34).ToString());

                                switch (eventArgs.Key)
                                {
                                    case Key.Add:
                                        ArithmeticOperationsCommand.Execute("+");
                                        break;
                                    case Key.Subtract:
                                        ArithmeticOperationsCommand.Execute("-");
                                        break;
                                    case Key.Multiply:
                                        ArithmeticOperationsCommand.Execute("*");
                                        break;
                                    case Key.Divide:
                                        ArithmeticOperationsCommand.Execute("/");
                                        break;
                                    case Key.D5:
                                        if (eventArgs.KeyboardDevice.Modifiers == ModifierKeys.Shift)
                                            ArithmeticOperationsCommand.Execute("%");
                                        break;
                                    case Key.Return:
                                        EqualCommand.Execute(null);
                                        break;
                                    case Key.Delete:
                                        ClearCommand.Execute(null);
                                        break;
                                    case Key.Back:
                                        BackCommand.Execute(null);
                                        break;
                                }
                            }
                        });
                return _keyDownCommand;
            }
        }

        private string CalculateOnp(string onpStr)
        {
            List<string> listOfElements = onpStr.Split(" ").ToList();
            Stack<int> stackOfNumbers = new Stack<int>();

            foreach (string element in listOfElements)
            {
                if (int.TryParse(element, out int number))
                {
                    stackOfNumbers.Push(number);
                }
                else
                {
                    int firstNumber = stackOfNumbers.Pop();
                    int secondNumber = stackOfNumbers.Pop();

                    int result = Calculate(secondNumber, firstNumber, element);

                    stackOfNumbers.Push(result);
                }
            }

            return onpStr;
        }

        private string GenerateOnp(string showValue)
        {
            string onpStr = "";

            //konwersja ShowValue na ONP
            List<string> outputList = new List<string>();
            Stack<string> operatorStack = new Stack<string>();
            Dictionary<string, int> operatorPriorityDictionary = new Dictionary<string, int>();
            operatorPriorityDictionary.Add("+", 10);
            operatorPriorityDictionary.Add("-", 10);
            operatorPriorityDictionary.Add("*", 20);
            operatorPriorityDictionary.Add("/", 20);
            operatorPriorityDictionary.Add("%", 20);

            //dodatkowe operatory
            //operatorPriorityDictionary.Add("^", 30);
            //operatorPriorityDictionary.Add("(", int.MinValue);

            List<string> listOfElements = showValue.Split(' ').ToList();

            foreach (string element in listOfElements)
            {
                if (int.TryParse(element, out _))
                {
                    outputList.Add(element);
                }
                else
                {
                    while (true)
                    {
                        if (operatorStack.Count == 0)
                            break;

                        string operatorOnTopOfStack = operatorStack.Peek();

                        if (operatorPriorityDictionary[operatorOnTopOfStack] >= operatorPriorityDictionary[element])
                        {
                            operatorOnTopOfStack = operatorStack.Pop();
                            outputList.Add(operatorOnTopOfStack);
                        }
                        else
                        {
                            break;
                        }
                    }

                    operatorStack.Push(element); 
                }
            }

            while (operatorStack.Count != 0)
            {
                string operatorOnTopOfStack = operatorStack.Pop();
                outputList.Add(operatorOnTopOfStack);
            }

            onpStr = string.Join(" ", outputList);

            return onpStr;
        }

        private int Calculate( int leftNumber, int rightNumber, string operatorToDo)
        {
            if (operatorToDo == "+")
                return leftNumber + rightNumber;
            else if (operatorToDo == "-")
                return leftNumber - rightNumber; 
            else if (operatorToDo == "*")
                return leftNumber * rightNumber;
            else if (operatorToDo == "/")
                return leftNumber / rightNumber;
            else if (operatorToDo == "%")
                return leftNumber % rightNumber;

            return 0;
        }
    }
}
