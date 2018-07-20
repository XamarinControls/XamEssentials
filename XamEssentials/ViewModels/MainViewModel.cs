using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamEssentials.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
      
        #region Fields

        private string _deviceBrand;
        private string _deviceModel;
        private string _deviceName;
        private string _devicePlatform;
        private string _connectivityText;
        private string _textToSpeak;

        private int _connectivity;

        private double _heading;

        private Command _speakCommand;

        public event PropertyChangedEventHandler PropertyChanged;


        #endregion

        #region Properties

        public string DeviceBrandText
        {
            get
            {
                return $"Brand: {_deviceBrand}";
            }
        }

        public string DeviceNameText
        {
            get
            {
                return $"Name: {_deviceName}";
            }
        }

        public string DeviceModelText
        {
            get
            {
                return $"Model: {_deviceModel}";
            }
        }

        public string DevicePlatformText
        {
            get
            {
                return $"Platform: {_devicePlatform}";
            }
        }

        public string ConnectivityText
        {
            get { return _connectivityText; }
            set { _connectivityText = value; 
                OnPropertyChanged();}
        }

        public string TextToSpeak
        {
            get { return _textToSpeak; }
            set { _textToSpeak = value; 
                OnPropertyChanged();}
        }

        public int Connectivity
        {
            get { return _connectivity; }
            set { _connectivity = value; 
                OnPropertyChanged();}
        }

        public double Heading
        {
            get { return _heading; }
            set
            {
                _heading = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public Command SpeakCommand
        {
            get { return _speakCommand; }
            set
            {
                _speakCommand = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            _deviceBrand =  DeviceInfo.Manufacturer;
            _deviceModel = DeviceInfo.Model;
            _deviceName = DeviceInfo.Name;
            _devicePlatform = DeviceInfo.Platform;
            _textToSpeak = string.Empty;

            _connectivity = 0;
            _connectivityText = "Unknown";
            _speakCommand = new Command(speak);

            Xamarin.Essentials.Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            Xamarin.Essentials.Compass.ReadingChanged += Compass_ReadingChanged;

            Xamarin.Essentials.Compass.Start(SensorSpeed.Ui);
        }
        #endregion

        #region Methods

        private void speak()
        {
            if (!string.IsNullOrEmpty(TextToSpeak))
            {
                TextToSpeech.SpeakAsync(TextToSpeak);
            }
        }

        void Connectivity_ConnectivityChanged(ConnectivityChangedEventArgs e)
        {
            var network = e.NetworkAccess.ToString();
            ConnectivityText = network;

            switch (network)
            {
                case "Internet":
                    Connectivity = 1;
                    break;
                case "None":
                    Connectivity = 2;
                    break;
                default:
                    Connectivity = 0;
                    break;
            }
        }

        void Compass_ReadingChanged(CompassChangedEventArgs e)
        {
            Heading = e.Reading.HeadingMagneticNorth;
        }

        protected void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null){
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

    }
}
