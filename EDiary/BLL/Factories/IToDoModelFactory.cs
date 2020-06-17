using DAL.Models;
using DAL.ViewModels;

namespace BLL.Factories
{
    public interface IToDoModelFactory
    {
        ToDoViewModel PrepareToDoViewModel(ToDoFilterModel filter, SimplePagerModel pager, string userId);
        ToDoViewModel PrepareTeacherToDoViewModel(ToDoFilterModel filter, SimplePagerModel pager, string userId);
    }
}
