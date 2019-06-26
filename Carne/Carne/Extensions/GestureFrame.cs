using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Carne.Extensions
{
        public class GestureFrame : Frame
        {
            public GestureFrame()
            {
                HasShadow = false;
                Margin = 0;
                Padding = 0;
            }

            public event EventHandler<EventArgs> SwipeDown;
            public event EventHandler<EventArgs> SwipeTop;
            public event EventHandler<EventArgs> SwipeLeft;
            public event EventHandler<EventArgs> SwipeRight;

            public void OnSwipeDown(object s, EventArgs e)
            {
                SwipeDown?.Invoke(this, null);
            }

            public void OnSwipeTop(object s, EventArgs e)
            {
                SwipeTop?.Invoke(this, null);
            }

            public void OnSwipeLeft(object s, EventArgs e)
            {
                SwipeLeft?.Invoke(this, null);
            }

            public void OnSwipeRight(object s, EventArgs e)
            {
                SwipeRight?.Invoke(this, null);
            }
        }
    
}
