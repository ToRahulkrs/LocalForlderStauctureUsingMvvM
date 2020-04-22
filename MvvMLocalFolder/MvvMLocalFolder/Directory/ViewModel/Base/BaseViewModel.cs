

using System.ComponentModel;

namespace MvvMLocalFolder
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (Sender, e)=>{};
    }
}
