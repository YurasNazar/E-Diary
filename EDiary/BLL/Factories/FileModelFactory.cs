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

        public TaskFileMapping PrepareTaskFileMappingModel(int taskId, int fileId)
        {
            return new TaskFileMapping
            {
                TaskId = taskId,
                FileId = fileId
            };
        }
    }
}
