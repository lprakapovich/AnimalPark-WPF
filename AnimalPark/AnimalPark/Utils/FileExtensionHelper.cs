using AnimalPark.Model.Enums;
using static AnimalPark.Model.Enums.FileExtension;

namespace AnimalPark.Utils
{
    public struct FileExtensionHelper
    {
        public class FileExtensionMetaData
        {
            public string Extension { get; set; }
            public string Filter { get; set; }
            public bool IsInvalid => string.IsNullOrEmpty(Extension) || string.IsNullOrEmpty(Filter);
        }

        public static FileExtensionMetaData ResolveFileExtension(FileExtension extension)
        {
            switch (extension)
            {
                case Dat:
                    return new FileExtensionMetaData() {Extension = ".dat", Filter = "Binary| *.dat"};
                case Xml:
                    return new FileExtensionMetaData() {Extension = ".xml", Filter = "XML | *.xml"};
                default:
                    return null;
            }
        }
    }
}
