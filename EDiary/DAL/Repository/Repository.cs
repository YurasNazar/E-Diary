using DAL.DatabaseContext;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly EDiaryDbContext _context;
        private DbSet<T> _entities;

        public Repository(EDiaryDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }


        public virtual T GetById(object id)
        {
            return Entities.Find(id);
        }

        public virtual void Insert(T entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Add(entity);

            _context.SaveChanges();
        }

        public virtual void Insert(IEnumerable<T> entities)
        {

            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Entities.AddRange(entities);

            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.SaveChanges();
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Remove(entity);

            _context.SaveChanges();
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Entities.RemoveRange(entities);
            _context.SaveChanges();
        }

        public virtual IQueryable<T> Table => Entities;

        public virtual IQueryable<T> TableNoTracking => Entities.AsNoTracking();

        protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}
