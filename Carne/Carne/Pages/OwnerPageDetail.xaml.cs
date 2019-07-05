using System;
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
            ViewModel = new DailyRecommendationsPageViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var masterPage = (OwnerPage)Parent?.Parent;

            if (masterPage != null)
                masterPage.IsGestureEnabled = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var masterPage = (OwnerPage)Parent?.Parent;

            if(masterPage !=null)
                masterPage.IsGestureEnabled = false;
        }
        private async void OnSwipeLeft(object sender, SwipedEventArgs e)
        {
            await Navigation.PushAsync(new MoreInformationPage(ViewModel));
        }

        private async void AccessAccountPopup(object sender, EventArgs e)
        {
            var result = await DisplayActionSheet(ViewModel.TestUser.UserName + "'s" + " Account", "Cancel", null, "Logout");

            switch (result)
            {
                case "Logout":
                    await Navigation.PopModalAsync();
                    break;
            }
        }

        private async void DeleteItemButtonClicked(object sender, EventArgs e)
        {
            var item = BindingContext as OwnerPageMenuItem;

            if (item != null)
            {
                MessagingCenter.Send(item, "Delete");

                BindingContext = null;
            }
            
        }
    }
}