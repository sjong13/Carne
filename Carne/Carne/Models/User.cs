using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Carne.Models
{
    public class User : INotifyPropertyChanged
    {
        private string userName;
        private Dictionary<int,double> personalPreference;
        private double pricePreference;

        public double PricePreference
        {
            get { return pricePreference; }
            set { pricePreference = value; NotifyPropertyChanged(); }
        }

        public Dictionary<int, double> PersonalPreference
        {
            get { return personalPreference; }
            set { personalPreference = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
