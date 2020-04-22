
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvMLocalFolder
{
    public static class DirectoryStructure
    {

        public static List<DirectoryItems> GetLogicalDrives()
        {
            return System.IO.Directory.GetLogicalDrives().Select(drive => new DirectoryItems { FullPath = drive, type = DirectoryItemType.Drive }).ToList();
        }

        public static List<DirectoryItems> GetDirectoryContent(string fullPath)
        {
            var item = new List<DirectoryItems>();
          
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    item.AddRange(dirs.Select(dir=>new DirectoryItems { FullPath=dir,type=DirectoryItemType.Drive}));
            }
            catch (Exception) { }


        
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    item.AddRange(fs.Select(dir=>new DirectoryItems { FullPath=dir,type=DirectoryItemType.Drive}));
            }
            catch (Exception) { }

            return item;
        }

        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;
            var normalizedPath = path.Replace('/', '\\');
            var lastIndex = normalizedPath.LastIndexOf('\\');
            if (lastIndex <= 0)
                return path;
            return path.Substring(lastIndex + 1);
        }
    }
}
