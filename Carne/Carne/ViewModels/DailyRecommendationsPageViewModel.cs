using Carne.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using static Carne.Models.Recommendation;

namespace Carne.ViewModels
{
    public class DailyRecommendationsPageViewModel : BaseViewModel
    {
        private int viewTime;
        private Stopwatch stopwatch;
        private int maxIndexReached = -1;
        private User testUser;
        public User TestUser
        {
            get { return testUser; }
            set { testUser = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Recommendation> Recommendations;
        private Recommendation currentRecommendation;

        private bool isLikeVisible;

        public bool IsLikeVisible
        {
            get { return isLikeVisible; }
            set { isLikeVisible = value; OnPropertyChanged(); }
        }

        public Recommendation CurrentRecommendation
        {
            get { return currentRecommendation; }
            set { currentRecommendation = value; OnPropertyChanged(); }
        }
        public int CurrentIndex;
        private double preferenceValue;
        public double PreferenceValue
        {
            get { return preferenceValue; }
            set { preferenceValue = value; OnPropertyChanged(); }
        }
        private string imageAddress;
        public string ImageAddress
        {
            get { return imageAddress; }
            set { imageAddress = value; OnPropertyChanged(); }
        }
        public DailyRecommendationsPageViewModel()
        {
            stopwatch = new Stopwatch();
            IsLikeVisible = false;
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));

            SetUpDummyData();
            
        }

        private void SetUpDummyData()
        {
            double initialPreference = 0.5;
            TestUser = new User
            {
                UserName = "txn3735",
                PersonalPreference = new Dictionary<int, double>
                {
                    { 0, initialPreference},
                    { 1, initialPreference},
                    { 2, initialPreference},
                    { 3, initialPreference},
                    { 4, initialPreference},
                    { 5, initialPreference},
                    { 6, initialPreference},
                    { 7, initialPreference},
                    { 8, initialPreference},
                    { 9, initialPreference},
                    {10, initialPreference}
                }
            };
            #region Prepopulated Recommendation List
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
                    RestaurantName = "Churrasco's",
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
                    RestaurantName = "Fictional Steakhouse",
                    ItemName = "Sous Vide New York Strip",
                    Cost = 47.99M,
                    ImageAddress = "https://www.seriouseats.com/recipes/images/2015/05/Anova-Steak-Guide-Sous-Vide-Photos15-beauty-1500x1125.jpg",
                    UniqueIdentifier = 10,
                    Quantity = 15,
                    MeatType = "Beef"
                },

            };
            #endregion
            PreLoadImages();
            InitializeRecommendation();
            
        }

        private void PreLoadImages()
        {
            foreach (var item in Recommendations)
            {
                item.CurrentImageSource = ImageSource.FromUri(new Uri(item.ImageAddress));
                item.DirectImage = new Image { Source = ImageSource.FromUri(new Uri(item.ImageAddress)) };
            }
        }

        private void InitializeRecommendation()
        {
            ObservableCollection<Recommendation> sorted = SortListByRating(Recommendations, TestUser);
            CurrentIndex = 0;
            PreferenceValue = TestUser.PersonalPreference.Where(t => t.Key == Recommendations[CurrentIndex].UniqueIdentifier).FirstOrDefault().Value;
            CurrentRecommendation = Recommendations[CurrentIndex];
            stopwatch.Start();
        }

        public async Task NextMeat()
        {
            if (CurrentIndex < Recommendations.Count - 1)
            {
                
                CheckPreferenceTimer();

                IncrementIndex();
            }
        }

        private void CheckPreferenceTimer()
        {

            //replace with more accurate function
            //if (stopwatch.ElapsedMilliseconds > 5000)
            {
                CalculatePreference(Convert.ToDouble(stopwatch.ElapsedMilliseconds));
            }
            stopwatch.Reset();
        }

        private void IncrementIndex()
        {
            CurrentIndex++;

            PreferenceValue = TestUser.PersonalPreference.Where(t => t.Key == Recommendations[CurrentIndex].UniqueIdentifier).FirstOrDefault().Value;

            CurrentRecommendation = Recommendations[CurrentIndex];

            stopwatch.Start();
        }

        public void PreviousMeat()
        {
            if(CurrentIndex > 0)
            {
                CurrentIndex--;
                PreferenceValue = TestUser.PersonalPreference.Where(t => t.Key == Recommendations[CurrentIndex].UniqueIdentifier).FirstOrDefault().Value;
                CurrentRecommendation = Recommendations[CurrentIndex];
            }
        }

        public void CalculatePreference(double elapsedMilliseconds)
        {

            if(elapsedMilliseconds > 5000)
            {
                TestUser.PersonalPreference[TestUser.PersonalPreference.Where(t => t.Key == Recommendations[CurrentIndex].UniqueIdentifier).FirstOrDefault().Key] = 1;
            }
            else
            {
                TestUser.PersonalPreference[TestUser.PersonalPreference.Where(t => t.Key == Recommendations[CurrentIndex].UniqueIdentifier).FirstOrDefault().Key] =
                   (elapsedMilliseconds / 5000);
            }


            SortListByRating(Recommendations, TestUser);
        }
      

        private ObservableCollection<Recommendation> SortListByRating(ObservableCollection<Recommendation> recommendations, User testUser)
        {
            double sumCost = 0;
            double sumQuantity = 0;
            double likedCount = 0;
            foreach (var item in Recommendations)
            {
                //if (TestUser.PersonalPreference.Where(t => t.Key == item.UniqueIdentifier).FirstOrDefault().Value == true)
                {
                    sumCost += Convert.ToDouble(item.Cost) * TestUser.PersonalPreference[TestUser.PersonalPreference.Where(t => t.Key == item.UniqueIdentifier).FirstOrDefault().Key];
                    sumQuantity += item.Quantity * TestUser.PersonalPreference[TestUser.PersonalPreference.Where(t => t.Key == item.UniqueIdentifier).FirstOrDefault().Key];
                    likedCount+= TestUser.PersonalPreference[TestUser.PersonalPreference.Where(t => t.Key == item.UniqueIdentifier).FirstOrDefault().Key];
                }
                    
            }
            var averagePrice = sumCost / likedCount;
            var averageQuantity = sumQuantity / likedCount;
            foreach (var recommendation in recommendations)
            {
                recommendation.PersonalRating = recommendation.OverallRating * 0.25 - 
                    Math.Abs(Convert.ToDouble(recommendation.Cost) - averagePrice) * 0.5 - Math.Abs(recommendation.Quantity - averageQuantity) * 0.25;
            }
            HoldUpToAndSort(Recommendations, CurrentIndex);
            return recommendations;
        }

        public void HoldUpToAndSort(ObservableCollection<Recommendation> list, int upTo)
        {
            ObservableCollection<Recommendation> staticPart = new ObservableCollection<Recommendation>();
            ObservableCollection<Recommendation> dynamicPart = new ObservableCollection<Recommendation>();
            int count = 0;

            foreach (var recommendation in list)
            {
                if(count<upTo+1)
                {
                    staticPart.Add(recommendation);
                }
                else
                {
                    dynamicPart.Add(recommendation);
                }
                count++;
            }

            //sort dynamic portion
            dynamicPart = new ObservableCollection<Recommendation>(dynamicPart.OrderByDescending(t => t.PersonalRating));

            foreach (var recommendation in dynamicPart)
            {
                staticPart.Add(recommendation);
            }

            Recommendations = staticPart;
        }
        public ICommand OpenWebCommand { get; }

        public Command ToggleLikeCommand { get; }
    }
}