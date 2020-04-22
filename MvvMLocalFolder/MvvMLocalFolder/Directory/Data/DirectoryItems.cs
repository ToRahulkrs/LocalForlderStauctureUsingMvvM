
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvMLocalFolder
{
    public class DirectoryItems
    {
        public DirectoryItemType type {get;set;}
        public string FullPath { get; set; }

        public string Name { get { return this.type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }
    }
}
