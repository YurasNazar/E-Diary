using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IToDoService
    {
        IList<ToDo> GetToDosList();
    }
}
