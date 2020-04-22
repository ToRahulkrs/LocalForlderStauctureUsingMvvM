
using System.Linq;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MvvMLocalFolder
{
    public class DirectoryItemViewModel :BaseViewModel
    {
        public DirectoryItemType type { get; set; }
        public string FullPath { get; set; }

        public string Name { get { return this.type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public ICommand ExpendCommand;
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            this.ExpendCommand = new RelayCommand(Expend);
            this.FullPath = fullPath;
            this.type = type;
            this.ClearChildren();
        }

        public bool CanExpend { get { return this.type != DirectoryItemType.File; } }
        public bool IsExpanded
        {
            get
            { 
                return this.Children?.Count(f=>f != null) >0; 
            }
            set
            {
                if (value == true)
                    Expend();
                else
                    this.ClearChildren();
            }
        }

        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();
            if (this.type != DirectoryItemType.File)
                this.Children.Add(null);
        }

        private void Expend()
        {
            if (this.type == DirectoryItemType.File)
                return;
            var children = DirectoryStructure.GetDirectoryContent(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(content => new DirectoryItemViewModel(content.FullPath, content.type)));
        }
    }
}
