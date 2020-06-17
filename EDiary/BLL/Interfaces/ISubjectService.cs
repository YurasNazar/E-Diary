using BLL.PagedList;
using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ISubjectService
    {
        public IPagedList<Subject> SearchSubjects(string userId = "");
        public IPagedList<Subject> SearchSubjectTeachers(int subjectId);
        public IPagedList<SubjectPost> SearchSubjectPosts(int subjectId);
        public IPagedList<UserSubjectMapping> SearchSubjectPeople(int subjectId);
        public IPagedList<UserSubjectMapping> SearchUserSubjectMapping(string userId = "");
        public Subject GetSubjectByCode(string joinCode);
        public List<UserSubjectMapping> GetSubjectUsers(int subjectId);
        public void CreateSubject(Subject subject);
        public void CreateUserSubjectMapping(UserSubjectMapping userSubjectMappingModel);
        public void CreateSubjectPost(SubjectPost subjectPost);
        public void CreateUserSubject(UserSubjectMapping userSubject);
    }
}
