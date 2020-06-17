using BLL.Interfaces;
using BLL.PagedList;
using DAL.Entities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IRepository<SubjectPost> _subjectPostRepository;
        private readonly IRepository<UserSubjectMapping> _userSubjectMapping;

        public SubjectService(IRepository<Subject> subjectRepository,
                              IRepository<SubjectPost> subjectPostRepository,
                              IRepository<UserSubjectMapping> userSubjectMapping)
        {
            _subjectRepository = subjectRepository;
            _userSubjectMapping = userSubjectMapping;
            _subjectPostRepository = subjectPostRepository;

        }

        public void CreateSubject(Subject subject)
        {
            _subjectRepository.Insert(subject);
        }

        public void CreateUserSubjectMapping(UserSubjectMapping userSubjectMappingModel)
        {
            _userSubjectMapping.Insert(userSubjectMappingModel);
        }

        public void CreateSubjectPost(SubjectPost subjectPost)
        {
            _subjectPostRepository.Insert(subjectPost);
        }

        public IPagedList<SubjectPost> SearchSubjectPosts(int subjectId)
        {
            var query = GetSearchSubjectPostsQuery(subjectId);

            return new PagedList<SubjectPost>(query, 0, int.MaxValue);
        }

        public IPagedList<Subject> SearchSubjects(string userId = "")
        {
            var query = GetSearchSubjectsQuery(userId);

            return new PagedList<Subject>(query, 0, int.MaxValue);
        }

        public IPagedList<UserSubjectMapping> SearchUserSubjectMapping(string userId = "")
        {
            var query = GetSearchUserSubjectsMappingQuery(userId);

            return new PagedList<UserSubjectMapping>(query, 0, int.MaxValue);
        }

        public IPagedList<UserSubjectMapping> SearchSubjectPeople(int subjectId)
        {
            var query = GetSearchSubjectPeopleQuery(subjectId);

            return new PagedList<UserSubjectMapping>(query, 0, int.MaxValue);
        }

        public IPagedList<Subject> SearchSubjectTeachers(int subjectId)
        {
            var query = GetSearchSubjectTeachersQuery(subjectId);

            return new PagedList<Subject>(query, 0, int.MaxValue);
        }

        private IQueryable<Subject> GetSearchSubjectsQuery(string userId)
        {
            var query = _subjectRepository.TableNoTracking.Include(x => x.Owner) as IQueryable<Subject>;

            query = query.Where(x => x.Owner.Id == userId);

            query = query.OrderBy(x => x.DateCreated);

            return query;
        }

        private IQueryable<UserSubjectMapping> GetSearchUserSubjectsMappingQuery(string userId)
        {
            var query = _userSubjectMapping.TableNoTracking.Include(x => x.User).Include(x => x.Subject) as IQueryable<UserSubjectMapping>;

            query = query.Where(x => x.User.Id == userId);

            query = query.OrderBy(x => x.Subject.DateCreated);

            return query;
        }

        private IQueryable<SubjectPost> GetSearchSubjectPostsQuery(int subjectId)
        {
            var query = _subjectPostRepository.TableNoTracking.Include(x => x.Subject).Include(x => x.CreatedBy) as IQueryable<SubjectPost>;

            query = query.Where(x => x.Subject.Id == subjectId);

            query = query.OrderByDescending(x => x.DateCreated);

            return query;
        }

        private IQueryable<UserSubjectMapping> GetSearchSubjectPeopleQuery(int subjectId)
        {
            var query = _userSubjectMapping.TableNoTracking.Include(x => x.Subject).Include(x => x.User) as IQueryable<UserSubjectMapping>;

            query = query.Where(x => x.Subject.Id == subjectId);

            return query;
        }

        private IQueryable<Subject> GetSearchSubjectTeachersQuery(int subjectId)
        {
            var query = _subjectRepository.TableNoTracking.Include(x => x.Owner) as IQueryable<Subject>;

            query = query.Where(x => x.Id == subjectId);

            return query;
        }

        public Subject GetSubjectByCode(string joinCode)
        {
            var query = _subjectRepository.TableNoTracking;

            query = query.Where(x => x.JoinCode == joinCode);

            return query.ToList().FirstOrDefault();
        }

        public void CreateUserSubject(UserSubjectMapping userSubject)
        {
            _userSubjectMapping.Insert(userSubject);
        }

        public List<UserSubjectMapping> GetSubjectUsers(int subjectId)
        {
            var query = _userSubjectMapping.TableNoTracking.Include(x => x.User).Include(x => x.Subject) as IQueryable<UserSubjectMapping>;

            query = query.Where(x => x.Subject.Id == subjectId);

            var pagedList = new PagedList<UserSubjectMapping>(query, 0, int.MaxValue);

            return pagedList.ToList();
        }
    }
}
