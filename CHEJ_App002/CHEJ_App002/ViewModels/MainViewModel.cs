namespace CHEJ_App002.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainViewModel : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Attributes

        private string _bolivares;

        private string _dollars;

        private string _euros;

        private string _pounds;

        #endregion Attributes

        #region Properties

        public string Bolivares
        {
            get
            {
                return _bolivares;
            }
            set
            {
                if (value != _bolivares)
                {
                    _bolivares = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bolivares"));
                }
            }
        }

        public string Dollars
        {
            get
            {
                return _dollars;
            }
            set
            {
                if (value != _dollars)
                {
                    _dollars = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dollars"));
                }
            }
        }

        public string Euros
        {
            get
            {
                return _euros;
            }
            set
            {
                if (value != _euros)
                {
                    _euros = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Euros"));
                }
            }
        }

        public string Pounds
        {
            get
            {
                return _pounds;
            }
            set
            {
                if (value != _pounds)
                {
                    _pounds = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pounds"));
                }
            }
        }

        #endregion Properties

        #region Commands

        public ICommand ConvertCommand
        {
            get { return new RelayCommand(Convert); }
        }

        #endregion Commands

        #region Constructor

        public MainViewModel()
        {
        }

        #endregion Constructor

        #region Methods

        private async void Convert()
        {
            if (string.IsNullOrEmpty(Bolivares))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Enter an amount in bolivares...!!!", "Acept");
                return;
            }

            decimal bolivares = 0;
            if (!decimal.TryParse(Bolivares, out bolivares))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Enter an amount numeric in bolivares...!!!", "Acept");
                Bolivares = null;
                Dollars = null;
                Euros = null;
                Pounds = null;
                return;
            }

            var dollars = bolivares / 3003.003M;
            var euros = bolivares / 3531.05105M;
            var pounds = bolivares / 3907.23724M;

            Dollars = string.Format("${0:N2}", dollars);
            Euros = string.Format("€{0:N2}", euros);
            Pounds = string.Format("£{0:N2}", pounds);

            await Application.Current.MainPage.DisplayAlert("Information", "Conversion completed", "Acept");
        }

        #endregion Methods
    }
}
