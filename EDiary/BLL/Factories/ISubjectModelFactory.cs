using DAL.Entities;
using DAL.ViewModels;

namespace BLL.Factories
{
    public interface ISubjectModelFactory
    {
        public SubjectListViewModel PrepareSubjectListViewModel(string userId);
        public SubjectViewModel PrepareSubjectViewModel(string userId);
        public Subject PrepareSubjectModel(CreateSubjectViewModel subjectViewModel, string userId);
        public UserSubjectMapping PrepareUserSubjectMappingModel(string userId, int subjectId);
    }
}
