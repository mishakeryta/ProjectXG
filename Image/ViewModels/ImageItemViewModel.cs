using System;
using System.ComponentModel;
using System.Windows.Input;

namespace ProjectXG
{
    class ImageItemViewModel : INotifyPropertyChanged
    {
        //realizetion of interface
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        #region Constructor
        public ImageItemViewModel(string fullPath)
        {
            this.FullPath = fullPath;
        }
        #endregion


        #region Path and name property
        //private mamber,full path to image
        private string mFullPath;
        public string FullPath
        {
            get
            {
                return mFullPath;
            }
            set
            {
                //if nathing change return 
                if (mFullPath == value)
                {
                    return;
                }

                mFullPath = value;

                PropertyChanged(this, new PropertyChangedEventArgs(nameof(FullPath)));
            }
        }
        public string Name { get { return ImageStructure.GetImageName(FullPath); } }
        #endregion

        #region Color property for border
        ImageBackgroundColor mBackgroundColor;
        public ImageBackgroundColor BackgroundColor
        {
            get
            {
                return mBackgroundColor;
            }
            set
            {
                if(value == mBackgroundColor)
                {
                    return;
                }
                mBackgroundColor = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(BackgroundColor)));
            }
        }
#endregion

    }
}

