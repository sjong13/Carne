using Carne.Models;
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

        public class OwnerPageMasterViewModel : INotifyPropertyChanged
        {
            private Recommendation temporaryRecommendation;
            public Recommendation TemporaryRecommendation
            {
                get { return temporaryRecommendation; }
                set { temporaryRecommendation = value; OnPropertyChanged(); }
            }
            public ObservableCollection<OwnerPageMenuItem> MenuItems { get; set; }
            public ObservableCollection<Recommendation> Recommendations;

            private ObservableCollection<Recommendation> ownerListings;

            public ObservableCollection<Recommendation> OwnerListings
            {
                get { return ownerListings; }
                set { ownerListings = value; OnPropertyChanged(); }
            }

            public string OwnerName = "Fogo de Chao";
            public OwnerPageMasterViewModel()
            {
                OwnerListings = new ObservableCollection<Recommendation>();
                Recommendations = new ObservableCollection<Recommendation>
            {
                new Recommendation
                {
                    RestaurantName = "Fogo de Chao",
                    ItemName = "Picanha",
                    Cost = 36.99M,
                    ImageAddress = "https://assets.simpleviewinc.com/simpleview/image/upload/crm/boston/2017-02-Fogo_Picanha_wLogo_AD50609F-C9FA-4721-AACE718077924B85_f5581424-3a17-435e-abbf70a6f40b8a8f.jpg",
                    UniqueIdentifier = 0,
                    Quantity = 99,
                    MeatType = "Beef"
                },
                new Recommendation
                {
                    RestaurantName = "My House",
                    ItemName = "Smoked Prime Rib",
                    Cost = 12.11M,
                    ImageAddress = "https://heygrillhey.com/wp-content/uploads/2017/12/farmto-table-5-683x1024.jpg",
                    Quantity = 99,
                    UniqueIdentifier = 1,
                MeatType = "Beef"
                },
                new Recommendation
                {
                    RestaurantName = "Pit Room BBQ",
                    ItemName = "Double Brisket Plate",
                    Cost = 23.99M,
                    ImageAddress = "https://res.cloudinary.com/sagacity/image/upload/c_crop,h_2000,w_3000,x_0,y_0/c_limit,dpr_auto,f_auto,fl_lossy,q_80,w_1080/0717-table-pinkerstons-bbq_z5djrn.jpg",
                    Quantity = 12,
                    UniqueIdentifier = 2,
                    MeatType = "Beef"
                },
                new Recommendation
                {
                    RestaurantName = "Laurenzo's",
                    ItemName = "Prime Rib",
                    Cost = 22.99M,
                    ImageAddress = "https://i.pinimg.com/originals/3f/19/f1/3f19f131be1514b666400ad6caece09f.jpg",
                    Quantity = 24,
                    UniqueIdentifier = 3,
                    MeatType = "Beef"
                },
                new Recommendation
                {
                    RestaurantName = "Taste of Texas",
                    ItemName = "Tomahawk Ribeye",
                    Cost = 63.99M,
                    ImageAddress = "https://img-aws.ehowcdn.com/700x/cdn.onlyinyourstate.com/wp-content/uploads/2017/10/tot2-700x467.jpg",
                    Quantity = 40,
                    UniqueIdentifier = 4,
                    MeatType = "Beef"
                },
                new Recommendation
                {
                    RestaurantName = "Peter Luger",
                    ItemName = "Porterhouse for 2",
                    Cost = 75.99M,
                    ImageAddress = "https://media2.trover.com/T/555cf85bae8d8a5ad0006cec/fixedw_large_4x.jpg",
                    Quantity = 32,
                    UniqueIdentifier = 5,
                    MeatType = "Beef"
                },
                new Recommendation
                {
                    RestaurantName = "Chama Gaucha",
                    ItemName = "Picanha",
                    Cost = 36.99M,
                    ImageAddress = "https://s.hdnux.com/photos/74/47/35/15890255/14/gallery_medium.jpg",
                    UniqueIdentifier = 6,
                    Quantity = 99,
                    MeatType = "Beef"
                },
                new Recommendation
                {
                    RestaurantName = "Bernie's Burger Bus",
                    ItemName = "Detention",
                    Cost = 23.00M,
                    ImageAddress = "https://s3-media4.fl.yelpcdn.com/bphoto/4I1m-8oUR7J5Ke3PfdlpTg/o.jpg",
                    UniqueIdentifier = 7,
                    Quantity = 20,
                    MeatType = "Beef"
                },
                new Recommendation
                {
                    RestaurantName = "Fogo de Chao",
                    ItemName = "Chimichurri Grilled Flank Steak",
                    Cost = 32.99M,
                    ImageAddress = "https://media4.s-nbcnews.com/i/newscms/2016_33/1152016/steak-chimichurri-stock-today-160819-tease_c04e0749f1ac327a956ce6feea877bed.jpg",
                    UniqueIdentifier = 8,
                    Quantity = 12,
                    MeatType = "Beef"
                },
                new Recommendation
                {
                    RestaurantName = "Doris",
                    ItemName = "Tomahawk Ribeye",
                    Cost = 56.99M,
                    ImageAddress = "https://s.hdnux.com/photos/60/41/45/12720459/3/920x920.jpg",
                    UniqueIdentifier = 9,
                    Quantity = 40,
                    MeatType = "Beef"
                },
                new Recommendation
                {
                    RestaurantName = "Fogo de Chao",
                    ItemName = "Sous Vide New York Strip",
                    Cost = 47.99M,
                    ImageAddress = "https://www.seriouseats.com/recipes/images/2015/05/Anova-Steak-Guide-Sous-Vide-Photos15-beauty-1500x1125.jpg",
                    UniqueIdentifier = 10,
                    Quantity = 15,
                    MeatType = "Beef"
                },

            };

                MenuItems = new ObservableCollection<OwnerPageMenuItem>();

                var match = Recommendations.Where(r => r.RestaurantName == OwnerName);
                var count = 0;
                foreach (var item in match)
                {
                    MenuItems.Add(new OwnerPageMenuItem { Id = count, Title = item.ItemName, ImageAddress = item.ImageAddress });
                    OwnerListings.Add(item);
                    count++;
                }

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

            public void SaveButtonClicked(object sender, EventArgs e)
            {
                MenuItems.Add(new OwnerPageMenuItem { Id = MenuItems.Count(), Title = TemporaryRecommendation.ItemName,
                    ImageAddress = null });
                OwnerListings.Add(TemporaryRecommendation);
            }
        }
        private async void AddButtonClicked(object sender, EventArgs e)
        {
            var vm = (OwnerPageMasterViewModel)BindingContext;

            vm.TemporaryRecommendation = new Recommendation();
            await Navigation.PushModalAsync(new NavigationPage(new AddRecommendationPage((OwnerPageMasterViewModel)BindingContext)));
        }

        private async void DeleteButtonClicked(object sender, EventArgs e)
        {
            var result = await DisplayActionSheet("Remove this entry?", null, null, "Yes", "No");

            switch(result)
            {
                case "Yes":
                    
                    break;
                case "No":
                    break;
            }
        }

        


    }
}