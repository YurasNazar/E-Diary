using DAL.Entities;

namespace BLL.Factories
{
    public interface IFileModelFactory
    {
        public File PrepareFileModel(string fileName, string path);
        public TaskFileMapping PrepareTaskFileMappingModel(int taskId, int fileId);
    }
}
