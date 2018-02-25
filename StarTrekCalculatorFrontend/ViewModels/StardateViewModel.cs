namespace DoenaSoft.STC
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Input;
    using ToolBox.Commands;

    sealed class StardateViewModel : INotifyPropertyChanged
    {
        readonly ICommand _DateToStardateCommand;

        readonly ICommand _SystemTimeToStardateCommand;

        readonly CultureInfo _Culture;

        string _Stardate;

        DateTime _Date;

        bool _Roundtrip;

        public StardateViewModel()
        {
            _DateToStardateCommand = new RelayCommand(DateToStardate);
            _SystemTimeToStardateCommand = new RelayCommand(SystemTimeToStardate);
            _Culture = Thread.CurrentThread.CurrentCulture;
            _Date = DateTime.Now;
            _Roundtrip = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DateToStardateCommand
            => _DateToStardateCommand;

        public ICommand SystemTimeToStardateCommand
            => _SystemTimeToStardateCommand;

        public string Stardate
        {
            get => _Stardate;
            set
            {
                if (value != _Stardate)
                {
                    _Stardate = value;

                    if (_Roundtrip == false && CanStardateToDate())
                    {
                        _Roundtrip = true;

                        StardateToDate();

                        _Roundtrip = false;
                    }

                    RaisePropertyChanged(nameof(Stardate));
                }
            }
        }

        public DateTime Date
        {
            get => _Date;
            set
            {
                if (value != _Date)
                {
                    _Date = value;

                    RaisePropertyChanged(nameof(Date));

                    if (_Roundtrip == false)
                    {
                        _Roundtrip = true;

                        DateToStardate();

                        _Roundtrip = false;
                    }
                }
            }
        }

        bool CanStardateToDate()
            => double.TryParse(Stardate, NumberStyles.AllowDecimalPoint, _Culture, out double stardate)
                && (stardate >= STC.Stardate.MinimumStarDate && stardate <= STC.Stardate.MaximumStarDate);

        void StardateToDate()
        {
            double stardate = double.Parse(Stardate, NumberStyles.AllowDecimalPoint, _Culture);

            Date = STC.Stardate.StarDateToNormalDate(stardate);
        }

        void DateToStardate()
        {
            double stardate = STC.Stardate.NormalDateToStarDate(Date);

            Stardate = stardate.ToString(_Culture);
        }

        void SystemTimeToStardate()
            => Date = DateTime.Now;

        void RaisePropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}