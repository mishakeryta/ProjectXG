
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

        public WindowStructureVeiwModel()
        {
            Items.Add(null);
        }

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


        //new command with allways can excute
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
                    IndexItemShown = 0;
                }
                Items.Add(image);
            }
        }
        public void Up()
        {
            if (0 >= IndexItemShown || Items[0] == null)
                return;
            Items[IndexItemShown].BackgroundColor = ImageBackgroundColor.White;
            --IndexItemShown;
            Items[IndexItemShown].BackgroundColor = ImageBackgroundColor.Blue;



        }

        public void Down()
        {

            if (Items.Count < IndexItemShown || Items[0] == null)
                return;
            Items[IndexItemShown].BackgroundColor = ImageBackgroundColor.White;
            ++IndexItemShown;
            Items[IndexItemShown].BackgroundColor = ImageBackgroundColor.Blue;

        }

        int mIndexItemShown = 0;
        public int IndexItemShown
        {
            get
            {
                return mIndexItemShown;
            }
            set
            {
                if (mIndexItemShown == value)
                {
                    return;
                }
                mIndexItemShown = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ShownImage)));
            }
        }
        public string ShownImage
        {
            get
            {
                if (Items.Count > IndexItemShown)
                {
                    return Items[IndexItemShown].FullPath;
                }
                else
                {
                    return null;
                }
            }
        }




    }
}
