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
using Carne.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Views.View;

[assembly: ResolutionGroupName("Carne")]
[assembly: ExportEffect(typeof(AndroidLongPressedEffect),"LongPressedEffect")]
namespace Carne.Droid.Extensions
{
    /// <summary>
    /// Android long pressed effect
    /// </summary>
    public class AndroidLongPressedEffect : PlatformEffect
    {
        private bool _attached;

        public static void Initialize() { }

        public AndroidLongPressedEffect()
        {

        }

        protected override void OnAttached()
        {
            if (!_attached)
            {
                if (Control != null)
                {
                    Control.LongClickable = true;
                    Control.LongClick += Control_LongClick;
                }
                else
                {
                    Container.LongClickable = true;
                    Container.LongClick += Control_LongClick;
                }
                _attached = true;
            }
        }

        private void Control_LongClick(object sender, LongClickEventArgs e)
        {
            Console.WriteLine("Invoking long click command");
            var command = LongPressedEffect.GetCommand(Element);
            command?.Execute(LongPressedEffect.GetCommandParameter(Element));
        }

        protected override void OnDetached()
        {
            if (_attached)
            {
                if (Control != null)
                {
                    Control.LongClickable = true;
                    Control.LongClick -= Control_LongClick;
                }
                else
                {
                    Container.LongClickable = true;
                    Container.LongClick -= Control_LongClick;
                }
                _attached = false;
            }
        }
    }
}