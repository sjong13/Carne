using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static Carne.Pages.OwnerPageMaster;

namespace Carne.Pages
{
    public partial class AddRecommendationPage : ContentPage
    {
        public OwnerPageMasterViewModel ViewModel;
        public AddRecommendationPage(OwnerPageMasterViewModel viewModel)
        {
            ViewModel = viewModel;
            BindingContext = ViewModel;
            InitializeComponent();
        }

        private async void AddImageButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("image", "image", "image");
        }

        private async void CancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void SaveButtonClicked(object sender, EventArgs e)
        {
            ViewModel.SaveButtonClicked(sender, e);
            await Navigation.PopModalAsync();
        }
    }
}
