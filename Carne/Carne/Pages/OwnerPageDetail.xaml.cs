﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carne.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Carne.Pages.OwnerPageMaster;

namespace Carne.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnerPageDetail : ContentPage
    {
        public DailyRecommendationsPageViewModel ViewModel;
        public OwnerPageDetail()
        {
            BindingContext = new OwnerPageMasterViewModel();
            ViewModel = new DailyRecommendationsPageViewModel();
            InitializeComponent();
        }

        private async void AccessAccountPopup(object sender, EventArgs e)
        {
            var result = await DisplayActionSheet(ViewModel.TestUser.UserName + "'s" + " Account", "Cancel", null, "Logout");

            switch (result)
            {
                case "Logout":
                    await Navigation.PushModalAsync(new LoginPage());
                    break;
            }
        }
    }
}