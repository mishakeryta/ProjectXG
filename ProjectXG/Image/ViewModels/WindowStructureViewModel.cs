
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;

//this cllass will handle all ViewModels
namespace ProjectXG
{
    class WindowStructureVeiwModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        #region Defoult constructor
        public WindowStructureVeiwModel()
        {
            Items.Add(null);
        }
        #endregion

        #region ObColaction property 
        private ObservableCollection<ImageItemViewModel> mItems = new ObservableCollection<ImageItemViewModel>();
        public ObservableCollection<ImageItemViewModel> Items
        {
            get
            {
                return mItems;
            }
            set
            {
                if (mItems == value)
                {
                    return;
                }
                mItems = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Items)));
            }

        }
        #endregion


        #region Commands fot buttons add methods for them
        private ICommand mClickAddCommand;
        public ICommand ClickAddCommand
        {
            get
            {
                //operato ?? return left if value is not null else...
                return mClickAddCommand ?? (mClickAddCommand = new CommandHandler(() => Add(), true));
            }
        }
        private ICommand mClickUpCommand;
        public ICommand ClickUpCommand
        {
            get
            {
                return mClickUpCommand ?? (mClickUpCommand = new CommandHandler(() => Up(), true));
            }
        }
        private ICommand mClickDownCommand;
        public ICommand ClickDownCommand
        {
            get
            {
                return mClickDownCommand ?? (mClickDownCommand = new CommandHandler(() => Down(), true));
            }
        }
        public void Add()
        {
            List<string> newImagesPaths = ImageStructure.GetImagesPathWhithHelpOfDialog();

            foreach (var path in newImagesPaths)
            {
                var image = new ImageItemViewModel(path)
                {
                    BackgroundColor = ImageBackgroundColor.White
                };
                if (Items[0] == null)
                {
                    Items.Clear();
                }
                Items.Add(image);
            }
        }
        public void Up()
        {
            if (mSelectedImage == null) return;
            int selectedIndex = Items.IndexOf(mSelectedImage);
            if (selectedIndex <= 0) return;
            SelectedImage = Items[selectedIndex - 1];

        }

        public void Down()
        {
            if (mSelectedImage == null) return;
            int selectedIndex = Items.IndexOf(mSelectedImage);
            if (selectedIndex >= (Items.Count - 1)) return;
            SelectedImage = Items[selectedIndex + 1];

        }
        #endregion

        #region Main image propertyse
        ImageItemViewModel mSelectedImage = null;
        public ImageItemViewModel SelectedImage
        {
            get
            {
                return mSelectedImage;
            }
            set
            {
                if (mSelectedImage == value)
                {
                    return;
                }
                mSelectedImage = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectedImage)));
            }
        }

        #endregion
    }
}
