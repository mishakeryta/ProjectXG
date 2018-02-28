using System;
using System.ComponentModel;
using System.Windows.Input;

namespace ProjectXG
{
    class ImageItemViewModel : INotifyPropertyChanged
    {
        public ImageItemViewModel(string fullPath)
        {
            this.FullPath = fullPath;
        }

        //realizetion of interface
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
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


    }
}

