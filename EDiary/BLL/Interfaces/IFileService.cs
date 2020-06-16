using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IFileService
    {
        public void SaveFile(File file);
        public void SaveTaskFileMappingModel(TaskFileMapping file);
    }
}
