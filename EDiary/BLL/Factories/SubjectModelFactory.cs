using BLL.Interfaces;
using DAL.Entities;
using DAL.Models;
using DAL.ViewModels;
using System;
using System.Linq;

namespace BLL.Factories
{
    public class SubjectModelFactory : ISubjectModelFactory
    {
        private readonly ISubjectService _subjectService;
        public SubjectModelFactory(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public SubjectListViewModel PrepareSubjectListViewModel(string userId)
        {
            var pagedList = _subjectService.SearchSubjects(userId);

            var subjectListViewModel = new SubjectListViewModel
            {
                SubjectList = pagedList.Select(PrepareSubjectModel).ToList(),
            };

            return subjectListViewModel;
        }

        public SubjectViewModel PrepareSubjectViewModel(string userId)
        {
            var pagedList = _subjectService.SearchUserSubjectMapping(userId);

            var subjectsViewModel = new SubjectViewModel
            {
                SubjectList = pagedList.Select(PrepareSubjectListItem).ToList(),
            };

            return subjectsViewModel;
        }

        public SubjectInfoModel PrepareSubjectInfoModel(int subjectId)
        {
            var subjectPostsPagedList = _subjectService.SearchSubjectPosts(subjectId);
            var subjectPeoplePagedList = _subjectService.SearchSubjectPeople(subjectId);
            var subjectTeachersPagedList = _subjectService.SearchSubjectTeachers(subjectId);

            var subjectInfoModel = new SubjectInfoModel
            {
                SubjectPosts = subjectPostsPagedList.Select(PreparePostModel).ToList(),
                SubjectPeople = subjectPeoplePagedList.Select(PreparePeopleModel).ToList(),
                SubjectTeachers = subjectTeachersPagedList.Select(PrepareTeachersModel).ToList()
            };

            return subjectInfoModel;
        }

        public SubjectListItem PrepareSubjectModel(Subject subject)
        {
            return new SubjectListItem
            {
                Name = subject.Name,
                Id = subject.Id
            };
        }

        public Subject PrepareSubjectModel(CreateSubjectViewModel subjectViewModel, string userId)
        {
            return new Subject
            {
                Name = subjectViewModel.Name,
                IsDeleted = false,
                OwnerId = userId,
                DateCreated = DateTime.UtcNow,
                JoinCode = subjectViewModel.JoinCode
            };
        }

        public SubjectListItem PrepareSubjectListItem(UserSubjectMapping userSubjectMapping)
        {
            return new SubjectListItem
            {
                Name = userSubjectMapping.Subject.Name,
                Id = userSubjectMapping.Subject.Id
            };
        }

        public UserSubjectMapping PrepareUserSubjectMappingModel(string userId, int subjectId)
        {
            return new UserSubjectMapping
            {
                UserId = userId,
                SubjectId = subjectId
            };
        }

        public Post PreparePostModel(SubjectPost post)
        {
            return new Post
            {
                CreatedByFullName = post.CreatedBy.FullName,
                DateCreated = post.DateCreated,
                Description = post.Description
            };
        }
        public Person PreparePeopleModel(UserSubjectMapping userSubject)
        {
            return new Person
            {
                FullName = userSubject.User.FullName,
            };
        }

        public Person PrepareTeachersModel(Subject subject)
        {
            return new Person
            {
                FullName = subject.Owner.FullName,
            };
        }

        public SubjectPost PrepareSubjectPostModelForInsert(int subjectId, string description, string userId)
        {
            return new SubjectPost
            {
                CreatedById = userId,
                Description = description,
                SubjectId = subjectId,
                DateCreated = DateTime.UtcNow,
            };
        }

        public UserSubjectMapping PrepareUserSubjectModelForInsert(int subjectId, string userId)
        {
            return new UserSubjectMapping
            {
               UserId = userId,
               SubjectId = subjectId
            };
        }
    }
}
