
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
    public partial class MoreInformationPage : ContentPage
    {
        public MoreInformationPage(ViewModels.DailyRecommendationsPageViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
            
        }

        private async void OnSwipeRight(object sender, SwipedEventArgs e)
        {
            if(Device.RuntimePlatform == Device.Android && Navigation.NavigationStack.Count > 1)
            await Navigation.PopAsync();
        }
    }
}