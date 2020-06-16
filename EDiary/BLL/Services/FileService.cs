using BLL.Interfaces;
using DAL.Entities;
using DAL.Repository;

namespace BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IRepository<File> _fileRepository;
        private readonly IRepository<TaskFileMapping> _taskFileMappingRepository;


        public FileService(IRepository<File> fileRepository,
                           IRepository<TaskFileMapping> taskFileMappingRepository)
        {
            _fileRepository = fileRepository;
            _taskFileMappingRepository = taskFileMappingRepository;
        }

        public void SaveFile(File file)
        {
            _fileRepository.Insert(file);
        }

        public void SaveTaskFileMappingModel(TaskFileMapping taskFile)
        {
            _taskFileMappingRepository.Insert(taskFile);
        }
    }
}
