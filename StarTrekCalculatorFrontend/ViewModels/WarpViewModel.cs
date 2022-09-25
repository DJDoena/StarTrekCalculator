namespace DoenaSoft.STC
{
    using System.ComponentModel;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Input;
    using STC.Resources;
    using ToolBox.Commands;
    using ToolBox.Extensions;
    using Calc = StarTrekCalculator;

    internal sealed class WarpViewModel : INotifyPropertyChanged
    {
        private readonly ICommand _warpToLightSpeedCommand;

        private readonly ICommand _lightSpeedToWarpCommand;

        private readonly CultureInfo _culture;

        private string _warp;

        private string _lightSpeed;

        private string _distance;

        private long _years;

        private short _days;

        private short _hours;

        private short _minutes;

        private short _seconds;

        private bool _roundtrip;

        public WarpViewModel()
        {
            _warpToLightSpeedCommand = new RelayCommand(this.WarpToLightspeed, this.CanWarpToLightspeed);

            _lightSpeedToWarpCommand = new RelayCommand(this.LightspeedToWarp, this.CanLightspeedToWarp);

            _culture = CultureInfo.CurrentCulture;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand WarpToLightspeedCommand => _warpToLightSpeedCommand;

        public ICommand LightspeedToWarpCommand => _lightSpeedToWarpCommand;

        public string Warp
        {
            get => _warp;
            set
            {
                if (value != _warp)
                {
                    _warp = value;

                    this.RaisePropertyChanged(nameof(this.Warp));
                    this.RaisePropertyChanged(nameof(this.WarpToLightspeedCommand));

                    if (_roundtrip == false)
                    {
                        _roundtrip = true;

                        if (this.CanWarpToLightspeed())
                        {
                            this.WarpToLightspeed();
                        }
                        else
                        {
                            this.Lightspeed = _warp.IsEmpty()
                                ? string.Empty
                                : Texts.NotApplicable;

                            this.ResetTravelTime();
                        }

                        _roundtrip = false;
                    }
                }
            }
        }

        public string Lightspeed
        {
            get => _lightSpeed;
            set
            {
                if (value != _lightSpeed)
                {
                    _lightSpeed = value;

                    this.RaisePropertyChanged(nameof(this.Lightspeed));
                    this.RaisePropertyChanged(nameof(this.LightspeedToWarpCommand));

                    if (_roundtrip == false)
                    {
                        _roundtrip = true;

                        if (this.CanLightspeedToWarp())
                        {
                            this.LightspeedToWarp();
                        }
                        else
                        {
                            this.Warp = _lightSpeed.IsEmpty()
                                ? string.Empty
                                : Texts.NotApplicable;

                            this.ResetTravelTime();
                        }

                        _roundtrip = false;
                    }
                }
            }
        }

        public string Distance
        {
            get => _distance;
            set
            {
                if (value != _distance)
                {
                    _distance = value;

                    this.RaisePropertyChanged(nameof(this.Distance));

                    this.TryCalculateTravelTime();
                }
            }
        }

        public long Years
        {
            get => _years;
            set
            {
                if (value != _years)
                {
                    _years = value;

                    this.RaisePropertyChanged(nameof(this.Years));
                }
            }
        }

        public short Days
        {
            get => _days;
            set
            {
                if (value != _days)
                {
                    _days = value;

                    this.RaisePropertyChanged(nameof(this.Days));
                }
            }
        }

        public short Hours
        {
            get => _hours;
            set
            {
                if (value != _hours)
                {
                    _hours = value;

                    this.RaisePropertyChanged(nameof(this.Hours));
                }
            }
        }

        public short Minutes
        {
            get => _minutes;
            set
            {
                if (value != _minutes)
                {
                    _minutes = value;

                    this.RaisePropertyChanged(nameof(this.Minutes));
                }
            }
        }

        public short Seconds
        {
            get => _seconds;
            set
            {
                if (value != _seconds)
                {
                    _seconds = value;

                    this.RaisePropertyChanged(nameof(this.Seconds));
                }
            }
        }

        private bool CanWarpToLightspeed() => double.TryParse(this.Warp, NumberStyles.Float, _culture, out double warp)
            && warp >= Calc.Warp.MinWarpFactor && warp <= Calc.Warp.MaxWarpFactor;

        private void WarpToLightspeed()
        {
            double warpFactor = double.Parse(this.Warp, NumberStyles.Float, _culture);

            var lightSpeed = Calc.Warp.WarpToLightSpeed(warpFactor);

            this.Lightspeed = lightSpeed.ToString(_culture);

            this.TryCalculateTravelTime(lightSpeed);
        }

        private bool CanLightspeedToWarp() => double.TryParse(this.Lightspeed, NumberStyles.Float, Thread.CurrentThread.CurrentCulture, out double lightspeed)
            && lightspeed >= Calc.Warp.MinLightSpeed && lightspeed <= Calc.Warp.MaxLightSpeed;

        private void LightspeedToWarp()
        {
            var lightSpeed = double.Parse(this.Lightspeed, NumberStyles.Float, _culture);

            var warpFactor = Calc.Warp.LightSpeedToWarp(lightSpeed);

            this.Warp = warpFactor.ToString(_culture);

            this.TryCalculateTravelTime(lightSpeed);
        }

        private void TryCalculateTravelTime()
        {
            if (this.CanLightspeedToWarp())
            {
                var lightSpeed = double.Parse(this.Lightspeed, NumberStyles.Float, _culture);

                this.TryCalculateTravelTime(lightSpeed);
            }
            else if (this.CanWarpToLightspeed())
            {
                var warpFactor = double.Parse(this.Warp, NumberStyles.Float, _culture);

                var lightSpeed = Calc.Warp.WarpToLightSpeed(warpFactor);

                this.TryCalculateTravelTime(lightSpeed);
            }
            else
            {
                this.ResetTravelTime();
            }
        }

        private void TryCalculateTravelTime(double lightspeed)
        {
            if (double.TryParse(this.Distance, NumberStyles.Float, _culture, out double distance)
                && distance > 0 && distance < 999999)
            {
                this.CalculateTravelTime(lightspeed, distance);
            }
            else
            {
                this.ResetTravelTime();
            }
        }

        private void CalculateTravelTime(double lightspeed, double distance)
        {
            var time = Calc.Warp.LightSpeedToTravelTime(lightspeed, distance);

            this.SetTravelTime(time);
        }

        private void ResetTravelTime()
        {
            this.SetTravelTime(new Calc.TravelTime());
        }

        private void SetTravelTime(Calc.TravelTime time)
        {
            this.Years = time.Years;
            this.Days = time.Days;
            this.Hours = time.Hours;
            this.Minutes = time.Minutes;
            this.Seconds = time.Seconds;
        }

        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}