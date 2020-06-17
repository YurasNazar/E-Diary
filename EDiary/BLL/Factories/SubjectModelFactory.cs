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

        public SubjectListItem PrepareSubjectModel(Subject subject)
        {
            return new SubjectListItem
            {
                Name = subject.Name
            };
        }

        public Subject PrepareSubjectModel(CreateSubjectViewModel subjectViewModel, string userId)
        {
            return new Subject
            {
                Name = subjectViewModel.Name,
                IsDeleted = false,
                OwnerId = userId,
                DateCreated = DateTime.UtcNow
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
    }
}
