using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Carne.Droid.Extensions;
using Carne.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(MoreInformationPage),typeof(AndroidCustomPageRenderer))]
namespace Carne.Droid.Extensions
{
    public class AndroidCustomPageRenderer : PageRenderer
    {
        
    }
}