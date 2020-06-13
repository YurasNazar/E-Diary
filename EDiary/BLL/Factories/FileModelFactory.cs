using DAL.Entities;

namespace BLL.Factories
{
    public class FileModelFactory : IFileModelFactory
    {
        public File PrepareFileModel(string fileName, string path)
        {
            return new File
            {
                Name = fileName,
                Path = path
            };
        }
    }
}
