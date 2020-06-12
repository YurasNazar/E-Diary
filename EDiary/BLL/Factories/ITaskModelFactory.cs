using DAL.ViewModels;

namespace BLL.Factories
{
    public interface ITaskModelFactory
    {
        public TaskViewModel PrepareTaskViewModel(int taskId, string userId = "");

        public TaskNotesViewModel PrepareTaskNotesViewModel(int taskId, string userId = "");
    }
}
