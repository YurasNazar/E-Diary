using BLL.Interfaces;
using DAL.Entities;
using DAL.Repository;

namespace BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IRepository<File> _fileRepository;

        public FileService(IRepository<File> fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public void SaveFile(File file)
        {
            _fileRepository.Insert(file);
        }
    }
}
