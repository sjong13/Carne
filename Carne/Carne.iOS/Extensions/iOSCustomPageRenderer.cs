using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carne.iOS.Extensions;
using Carne.Pages;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly:ExportRenderer(typeof(MoreInformationPage),typeof(iOSCustomPageRenderer))]
namespace Carne.iOS.Extensions
{
    public class iOSCustomPageRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if(ViewController.NavigationController != null)
            {
                ViewController.NavigationController.InteractivePopGestureRecognizer.Enabled = true;
                ViewController.NavigationController.InteractivePopGestureRecognizer.Delegate = new UIGestureRecognizerDelegate();
            }
            
        }
    }
}