using BLL.PagedList;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface ISubjectService
    {
        public IPagedList<Subject> SearchSubjects(string userId = "");
        public IPagedList<UserSubjectMapping> SearchUserSubjectMapping(string userId = "");
        public void CreateSubject(Subject subject);
        void CreateUserSubjectMapping(UserSubjectMapping userSubjectMappingModel);
    }
}
