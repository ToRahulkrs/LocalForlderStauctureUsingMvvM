

using System.Collections.ObjectModel;
using System.Linq;

namespace MvvMLocalFolder
{
    public class DirectoryStructureViewModel:BaseViewModel
    {
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrives();
            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(content => new DirectoryItemViewModel(content.FullPath, DirectoryItemType.Drive)));
        }
    }
}
