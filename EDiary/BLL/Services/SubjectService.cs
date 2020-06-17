using BLL.Interfaces;
using BLL.PagedList;
using DAL.Entities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IRepository<UserSubjectMapping> _userSubjectMapping;

        public SubjectService(IRepository<Subject> subjectRepository,
                              IRepository<UserSubjectMapping> userSubjectMapping)
        {
            _subjectRepository = subjectRepository;
            _userSubjectMapping = userSubjectMapping;
        }

        public void CreateSubject(Subject subject)
        {
            _subjectRepository.Insert(subject);
        }

        public void CreateUserSubjectMapping(UserSubjectMapping userSubjectMappingModel)
        {
            _userSubjectMapping.Insert(userSubjectMappingModel);
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
    }
}
