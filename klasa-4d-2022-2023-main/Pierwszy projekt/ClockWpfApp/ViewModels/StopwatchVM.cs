using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilitiesWpf;

namespace ClockWpfApp.ViewModels
{
    class StopwatchVM : ObserverVM
    {
		private string _timeStorage;

		public string TimeStorage
		{
			get { return _timeStorage; }
			set 
			{
				_timeStorage = value; 
				OnPropertyChanged(nameof(TimeStorage));
			}
		}

		private ICommand _startCommand;

		public ICommand StartCommand
		{
			get 
			{
				if (_startCommand == null)
					_startCommand = new RelayCommand<object>(
						o =>
						{

						});
				return _startCommand;
			}
		}
        private ICommand _stopCommand;

        public ICommand StopCommand
        {
            get
            {
                if (_stopCommand == null)
                    _stopCommand = new RelayCommand<object>(
                        o =>
                        {

                        });
                return _stopCommand;
            }
        }

    }
}
