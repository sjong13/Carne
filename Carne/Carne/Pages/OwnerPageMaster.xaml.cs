using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carne.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnerPageMaster : ContentPage
    {
        public ListView ListView;

        public OwnerPageMaster()
        {
            InitializeComponent();

            BindingContext = new OwnerPageMasterViewModel();
            ListView = MenuItemsListView;
            ListView.SeparatorVisibility = SeparatorVisibility.Default;
        }

        class OwnerPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<OwnerPageMenuItem> MenuItems { get; set; }

            public OwnerPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<OwnerPageMenuItem>(new[]
                {
                    new OwnerPageMenuItem { Id = 0, Title = "Meat 1" },
                    new OwnerPageMenuItem { Id = 1, Title = "Meat 2" },
                    new OwnerPageMenuItem { Id = 2, Title = "Meat 3" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private async void DeleteButtonClicked(object sender, EventArgs e)
        {
            var result = await DisplayActionSheet("Remove this entry?", null, null, "Yes", "No");

            switch(result)
            {
                case "Yes":
                    await DisplayAlert(null, "Entry Removed", "Ok");
                    break;
                case "No":
                    break;
            }
        }


    }
}