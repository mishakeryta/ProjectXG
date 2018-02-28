
using System.ComponentModel;


namespace ProjectXG
{
   
    //doesnt  work . Need to downlaad plugin
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
