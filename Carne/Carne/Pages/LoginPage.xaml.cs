using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carne.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void UserClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new DailyRecommendationsPage()));
        }

        private async void OwnerClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new OwnerPage());
        }
    }
}