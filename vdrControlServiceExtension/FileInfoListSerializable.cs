namespace vdrControlServiceExtension
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class FileInfoListSerializable
    {
        public List<FileInfoSerializable> FileList { get; set; }

        public FileInfoListSerializable()
        {
            FileList = new List<FileInfoSerializable>();
        }

        public void Add(FileInfoSerializable fileInfo)
        {
            FileList.Add(fileInfo);
        }

        public void Remove(FileInfoSerializable fileInfo)
        {
            FileList.Remove(fileInfo);
        }
    }
}
