using System;
using System.ComponentModel;

namespace ProjectXG
{
    class MouseCordinateViewModel
    {
        public class MouseWindowViewModel : INotifyPropertyChanged
        {
            private double mPanelX;
            private double mPanelY;

            public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };


            public double PanelX
            {
                get { return mPanelX; }
                set
                {
                    if (value.Equals(mPanelX)) return;
                    mPanelX = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(PanelX)));
                }
            }

            public double PanelY
            {
                get { return mPanelY; }
                set
                {
                    if (value.Equals(mPanelY)) return;
                    mPanelY = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(PanelY)));
                }
            }
        }
    }
}
