using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPServer.Abstract
{
    public interface IFTPFactory<T>
    {
        void CreateDirectory(string remoteDirectoryName);
        void ReName(string currentName, string newName);
        void GotoDirectory(string DirectoryName, bool IsRoot);
        void RemoveDirectory(string remoteDirectoryName);
        void Upload(string localFilePath);
        void DeleteFile(string remoteFileName);
        List<T> ListFilesAndDirectories();
        List<T> ListFiles();
        List<T> ListDirectories();
        bool IsExist(string remoteName);
        bool IsDirectoryExist(string remoteDirectoryName);
        bool IsFileExist(string remoteFileName);
        void Download(string saveFilePath, string downloadFileName);

    }
}
