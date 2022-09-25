namespace DoenaSoft.STC
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Input;
    using ToolBox.Commands;
    using Calc = StarTrekCalculator;

    internal sealed class StardateViewModel : INotifyPropertyChanged
    {
        private readonly ICommand _dateToStardateCommand;

        private readonly ICommand _systemTimeToStardateCommand;

        private readonly CultureInfo _culture;

        private string _stardate;

        private DateTime _date;

        private bool _roundtrip;

        public StardateViewModel()
        {
            _dateToStardateCommand = new RelayCommand(this.DateToStardate);

            _systemTimeToStardateCommand = new RelayCommand(this.SystemTimeToStardate);

            _culture = CultureInfo.CurrentCulture;

            _date = DateTime.Now;

            _roundtrip = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DateToStardateCommand => _dateToStardateCommand;

        public ICommand SystemTimeToStardateCommand => _systemTimeToStardateCommand;

        public string Stardate
        {
            get => _stardate;
            set
            {
                if (value != _stardate)
                {
                    _stardate = value;

                    if (_roundtrip == false && this.CanStardateToDate())
                    {
                        _roundtrip = true;

                        this.StardateToDate();

                        _roundtrip = false;
                    }

                    this.RaisePropertyChanged(nameof(this.Stardate));
                }
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                if (value != _date)
                {
                    _date = value;

                    this.RaisePropertyChanged(nameof(this.Date));

                    if (_roundtrip == false)
                    {
                        _roundtrip = true;

                        this.DateToStardate();

                        _roundtrip = false;
                    }
                }
            }
        }

        private bool CanStardateToDate() => double.TryParse(this.Stardate, NumberStyles.Float, _culture, out double stardate)
            && stardate >= Calc.Stardate.MinStardate && stardate <= Calc.Stardate.MaxStardate;

        private void StardateToDate()
        {
            var stardate = double.Parse(this.Stardate, NumberStyles.Float, _culture);

            this.Date = Calc.Stardate.StardateToNormalDate(stardate);
        }

        private void DateToStardate()
        {
            var stardate = Calc.Stardate.NormalDateToStardate(this.Date);

            this.Stardate = stardate.ToString(_culture);
        }

        private void SystemTimeToStardate() => this.Date = DateTime.Now;

        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}