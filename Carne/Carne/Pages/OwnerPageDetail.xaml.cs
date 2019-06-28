using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Carne.Pages.OwnerPageMaster;

namespace Carne.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnerPageDetail : ContentPage
    {
        public OwnerPageDetail()
        {
            BindingContext = new OwnerPageMasterViewModel();
            InitializeComponent();
        }
    }
}