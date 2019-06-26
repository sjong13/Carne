using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Carne.Models
{
    public class Recommendation : INotifyPropertyChanged
    {
        
        private int uniqueIdentifier;
        private string imageAddress;
        private string restaurantName;
        private decimal cost;
        private string itemName;
        private double overallRating;
        private double personalRating;
        private string meatType;
        private double quantity;
        private Image directImage;

        private ImageSource currentImageSource;

        public ImageSource CurrentImageSource
        {
            get { return currentImageSource; }
            set { currentImageSource = value; NotifyPropertyChanged(); }
        }


        public Image DirectImage
        {
            get { return directImage; }
            set { directImage = value; NotifyPropertyChanged(); }
        }

        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; NotifyPropertyChanged(); }
        }
        public string MeatType
        {
            get { return meatType; }
            set { meatType = value; NotifyPropertyChanged(); }
        }
        public double OverallRating
        {
            get { return overallRating; }
            set { overallRating = value; NotifyPropertyChanged(); }
        }
        public double PersonalRating
        {
            get { return personalRating; }
            set { personalRating = value; NotifyPropertyChanged(); }
        }
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; NotifyPropertyChanged(); }
        }
        public decimal Cost
        {
            get { return cost; }
            set { cost = value; NotifyPropertyChanged(); }
        }
        public string RestaurantName
        {
            get { return restaurantName; }
            set { restaurantName = value; NotifyPropertyChanged(); }
        }
        public string ImageAddress
        {
            get { return imageAddress; }
            set { imageAddress = value; NotifyPropertyChanged(); }
        }
        public int UniqueIdentifier
        {
            get { return uniqueIdentifier; }
            set { uniqueIdentifier = value; NotifyPropertyChanged(); }
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
