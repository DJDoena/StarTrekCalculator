namespace DoenaSoft.STC
{
    using System.ComponentModel;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Input;
    using ToolBox.Commands;
    using ToolBox.Extensions;

    sealed class WarpViewModel : INotifyPropertyChanged
    {
        readonly ICommand _WarpToLightspeedCommand;

        readonly ICommand _LightspeedToWarpCommand;

        readonly CultureInfo _Culture;

        string _Warp;

        string _Lightspeed;

        string _Distance;

        ulong _Years;

        ushort _Days;

        ushort _Hours;

        ushort _Minutes;

        ushort _Seconds;

        bool _Roundtrip;

        public WarpViewModel()
        {
            _WarpToLightspeedCommand = new RelayCommand(WarpToLightspeed, CanWarpToLightspeed);
            _LightspeedToWarpCommand = new RelayCommand(LightspeedToWarp, CanLightspeedToWarp);
            _Culture = Thread.CurrentThread.CurrentCulture;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand WarpToLightspeedCommand
            => _WarpToLightspeedCommand;

        public ICommand LightspeedToWarpCommand
            => _LightspeedToWarpCommand;

        public string Warp
        {
            get => _Warp;
            set
            {
                if (value != _Warp)
                {
                    _Warp = value;

                    RaisePropertyChanged(nameof(Warp));
                    RaisePropertyChanged(nameof(WarpToLightspeedCommand));

                    if (_Roundtrip == false)
                    {
                        _Roundtrip = true;

                        if (CanWarpToLightspeed())
                        {
                            WarpToLightspeed();
                        }
                        else
                        {
                            Lightspeed = _Warp.IsEmpty() ? string.Empty : Resources.NotApplicable;

                            ResetTravelTime();
                        }

                        _Roundtrip = false;
                    }
                }
            }
        }

        public string Lightspeed
        {
            get => _Lightspeed;
            set
            {
                if (value != _Lightspeed)
                {
                    _Lightspeed = value;

                    RaisePropertyChanged(nameof(Lightspeed));
                    RaisePropertyChanged(nameof(LightspeedToWarpCommand));

                    if (_Roundtrip == false)
                    {
                        _Roundtrip = true;

                        if (CanLightspeedToWarp())
                        {
                            LightspeedToWarp();
                        }
                        else
                        {
                            Warp = _Lightspeed.IsEmpty() ? string.Empty : Resources.NotApplicable;

                            ResetTravelTime();
                        }

                        _Roundtrip = false;
                    }
                }
            }
        }

        public string Distance
        {
            get => _Distance;
            set
            {
                if (value != _Distance)
                {
                    _Distance = value;

                    RaisePropertyChanged(nameof(Distance));

                    TryCalculateTravelTime();
                }
            }
        }

        public ulong Years
        {
            get => _Years;
            set
            {
                if (value != _Years)
                {
                    _Years = value;

                    RaisePropertyChanged(nameof(Years));
                }
            }
        }

        public ushort Days
        {
            get => _Days;
            set
            {
                if (value != _Days)
                {
                    _Days = value;

                    RaisePropertyChanged(nameof(Days));
                }
            }
        }

        public ushort Hours
        {
            get => _Hours;
            set
            {
                if (value != _Hours)
                {
                    _Hours = value;

                    RaisePropertyChanged(nameof(Hours));
                }
            }
        }

        public ushort Minutes
        {
            get => _Minutes;
            set
            {
                if (value != _Minutes)
                {
                    _Minutes = value;

                    RaisePropertyChanged(nameof(Minutes));
                }
            }
        }

        public ushort Seconds
        {
            get => _Seconds;
            set
            {
                if (value != _Seconds)
                {
                    _Seconds = value;

                    RaisePropertyChanged(nameof(Seconds));
                }
            }
        }

        bool CanWarpToLightspeed()
            => double.TryParse(Warp, NumberStyles.AllowDecimalPoint, _Culture, out double warp)
                && (warp >= STC.Warp.MinimumWarp && warp <= STC.Warp.MaximumWarp);

        void WarpToLightspeed()
        {
            double warp = double.Parse(Warp, NumberStyles.AllowDecimalPoint, _Culture);

            double lightspeed = STC.Warp.WarpToLightspeed(warp);

            Lightspeed = lightspeed.ToString(_Culture);

            TryCalculateTravelTime(lightspeed);
        }

        bool CanLightspeedToWarp()
            => double.TryParse(Lightspeed, NumberStyles.AllowDecimalPoint, Thread.CurrentThread.CurrentCulture, out double lightspeed)
                && (lightspeed >= STC.Warp.MinimumLightspeed && lightspeed <= STC.Warp.MaximumLightspeed);

        void LightspeedToWarp()
        {
            double lightspeed = double.Parse(Lightspeed, NumberStyles.AllowDecimalPoint, _Culture);

            double warp = STC.Warp.LightspeedToWarp(lightspeed);

            Warp = warp.ToString(_Culture);

            TryCalculateTravelTime(lightspeed);
        }

        void TryCalculateTravelTime()
        {
            if (CanLightspeedToWarp())
            {
                double lightspeed = double.Parse(Lightspeed, NumberStyles.AllowDecimalPoint, _Culture);

                TryCalculateTravelTime(lightspeed);
            }
            else if (CanWarpToLightspeed())
            {
                double warp = double.Parse(Warp, NumberStyles.AllowDecimalPoint, _Culture);

                double lightspeed = STC.Warp.WarpToLightspeed(warp);

                TryCalculateTravelTime(lightspeed);
            }
            else
            {
                ResetTravelTime();
            }
        }

        void TryCalculateTravelTime(double lightspeed)
        {
            if (double.TryParse(Distance, NumberStyles.AllowDecimalPoint, _Culture, out double distance)
                && (distance > 0 && distance < STC.Warp.MaximumDistance))
            {
                CalculateTravelTime(lightspeed, distance);
            }
            else
            {
                ResetTravelTime();
            }
        }

        void CalculateTravelTime(double lightspeed, double distance)
        {
            TravelTime time = STC.Warp.LightspeedToTime(lightspeed, distance);

            SetTravelTime(time);
        }

        void ResetTravelTime()
        {
            SetTravelTime(new TravelTime());
        }

        void SetTravelTime(TravelTime time)
        {
            Years = time.Years;
            Days = time.Days;
            Hours = time.Hours;
            Minutes = time.Minutes;
            Seconds = time.Seconds;
        }

        void RaisePropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}