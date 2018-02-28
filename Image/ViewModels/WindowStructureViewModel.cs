
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
                if(mItems == value)
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

        public void Add()
        {
            List<string> newImagesPaths = ImageStructure.GetImagesPathWhithHelpOfDialog();
            foreach (var path in newImagesPaths)
            {
                var image = new ImageItemViewModel(path);
                Items.Add(image);
            }
        }

    }
}
