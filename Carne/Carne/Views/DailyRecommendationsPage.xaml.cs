using Carne.Models;
using Carne.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Carne.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class DailyRecommendationsPage : ContentPage
    {
       
        public DailyRecommendationsPageViewModel ViewModel;

        public DailyRecommendationsPage()
        {
            InitializeComponent();
            ViewModel = (DailyRecommendationsPageViewModel)BindingContext;
        }

        private async void OnSwipeUp(object sender, SwipedEventArgs e)
        {
            MeatImage.FadeTo(0);
            await MeatImage.TranslateTo(MeatImage.X, MeatImage.Y - 300);
            await ViewModel.NextMeat();
            await MeatImage.TranslateTo(MeatImage.X, MeatImage.Y + 300,0);
            MeatImage.FadeTo(1);
            await MeatImage.TranslateTo(MeatImage.X, MeatImage.Y);
            
        }

        private async void OnSwipeLeft(object sender, SwipedEventArgs e)
        {
            await Navigation.PushAsync(new MoreInformationPage(ViewModel));
        }
    }
}