using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyTaskApp
{
    internal class MainVM : BindableObject
    {
		private ICommand _setOnCommand;

		public ICommand SetOnCommand
		{
			get 
			{
				if (_setOnCommand == null)
					_setOnCommand = new Command<object>(
						async o =>
						{
                            try
                            {
                                // Turn On
                                await Flashlight.TurnOnAsync();
                            }
                            catch (FeatureNotSupportedException fnsEx)
                            {
                                // Handle not supported on device exception
                            }
                            catch (PermissionException pEx)
                            {
                                // Handle permission exception
                            }
                            catch (Exception ex)
                            {
                                // Unable to turn on/off flashlight
                            }
                        }
						);
				return _setOnCommand; 
			}
		}

		private ICommand _setOffCommand;

		public ICommand SetOffCommand
		{
			get 
			{
                if (_setOffCommand == null)
                    _setOffCommand = new Command<object>(
                        async o =>
                        {
                            try
                            {
                                // Turn Off
                                await Flashlight.TurnOffAsync();
                            }
                            catch (FeatureNotSupportedException fnsEx)
                            {
                                // Handle not supported on device exception
                            }
                            catch (PermissionException pEx)
                            {
                                // Handle permission exception
                            }
                            catch (Exception ex)
                            {
                                // Unable to turn on/off flashlight
                            }
                        });
				return _setOffCommand;
			}
		}

        private string _longitude;

        public string Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                _longitude = value;
                OnPropertyChanged(nameof(Longitude));
            }
        }

        private string _latitude;

        public string Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                _latitude = value;
                OnPropertyChanged(nameof(Latitude));
            }
        }

        private string _altitude;

        public string Altitude
        {
            get
            {
                return _altitude;
            }
            set
            {
                _altitude = value;
                OnPropertyChanged(nameof(Altitude));
            }
        }

        private ICommand _getLocalisation;

        public ICommand GetLocalisation
        {
            get 
            {
                if (_getLocalisation == null)
                    _getLocalisation = new Command<object>(
                        async o =>
                        {
                            try
                            {
                               
                                var location = await Geolocation.GetLocationAsync();

                                if (location != null)
                                {
                                    Longitude = location.Longitude.ToString();
                                    Latitude = location.Latitude.ToString();
                                    Altitude = location.Altitude.ToString();
                                }
                            }
                            catch (FeatureNotSupportedException fnsEx)
                            {
                                // Handle not supported on device exception
                            }
                            catch (FeatureNotEnabledException fneEx)
                            {
                                // Handle not enabled on device exception
                            }
                            catch (PermissionException pEx)
                            {
                                // Handle permission exception
                            }
                            catch (Exception ex)
                            {
                                // Unable to get location
                            }
                        });
                return _getLocalisation; 
            }
        }

        private ICommand _vibrate;

        public ICommand Vibrate
        {
            get 
            {
                if (_vibrate == null)
                    _vibrate = new Command<object>(
                        async o =>
                        {
                            try
                            {
                                // Use default vibration length
                                Vibration.Vibrate();

                                // Or use specified time
                                var duration = TimeSpan.FromSeconds(1);
                                Vibration.Vibrate(duration);
                            }
                            catch (FeatureNotSupportedException ex)
                            {
                                // Feature not supported on device
                            }
                            catch (Exception ex)
                            {
                                // Other error has occurred.
                            }
                        });
                return _vibrate;
            }
        }

        private ICommand _tts;

        public ICommand TTS
        {
            get 
            {
                if (_tts == null)
                    _tts = new Command<object>(
                        async o =>
                        {
                            await TextToSpeech.SpeakAsync("Hello World!");
                        }
                        );
                return _tts;
            }
        }

    }
}
