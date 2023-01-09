using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilitiesWpf;

namespace ClockWpfApp.ViewModels
{
    class StopwatchVM : ObserverVM
    {
        private bool isStopWatchRunning = false;

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
                            isStopWatchRunning = true;
                            Task.Run(() =>
                            {
                                DateTime startTime = DateTime.Now;
                                //int stopwatchMillisecond = 0;
                                while (isStopWatchRunning)
                                {
                                    //stopwatchMillisecond++;
                                    //TimeSpan timeSpan = TimeSpan.FromMilliseconds(stopwatchMillisecond);

                                    TimeSpan timeSpan = DateTime.Now - startTime;
                                    string stringTime = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                                        timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

                                    TimeStorage = stringTime;

                                    Thread.Sleep(1);
                                }
                            });
                        },
                        o => !isStopWatchRunning
                        );
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
                            isStopWatchRunning = false;
                        },
                        o => isStopWatchRunning
                        );
                return _stopCommand;
            }
        }

		private ICommand _flagCommand;

		public ICommand FlagCommand
		{
            get
            {
                if (_flagCommand == null)
                    _flagCommand = new RelayCommand<object>(
                        o =>
                        {

                        });
                return _flagCommand;
            }
        }

		private string _flagValue;

		public string FlagValue
		{
            get { return _flagValue; }
            set
            {
                _flagValue = value;
                OnPropertyChanged(nameof(FlagValue));
            }
        }

	}
}
