using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carne.Extensions;
using Carne.iOS.Extensions;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Carne")]
[assembly: ExportEffect(typeof(iOSLongPressedEffect),"LongPressedEffect")]
namespace Carne.iOS.Extensions
{
    public class iOSLongPressedEffect : PlatformEffect
    {
        private bool _attached;
        private readonly UILongPressGestureRecognizer _longPressRecognizer;

        public iOSLongPressedEffect()
        {
            _longPressRecognizer = new UILongPressGestureRecognizer(HandleLongClick);
        }

        protected override void OnAttached()
        {
            if (!_attached)
            {
                Container.AddGestureRecognizer(_longPressRecognizer);
                _attached = true;
            }
        }

        private void HandleLongClick()
        {
            var command = LongPressedEffect.GetCommand(Element);
            command?.Execute(LongPressedEffect.GetCommandParameter(Element));
        }

        protected override void OnDetached()
        {
            if (_attached)
            {
                Container.RemoveGestureRecognizer(_longPressRecognizer);
                _attached = false;
            }
        }

    }
}