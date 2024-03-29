﻿using ECommerceSampleClassLibrary.Context;
using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Interfaces;

namespace ECommerceSampleClassLibrary.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseDomain
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.AddRange(entities);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.RemoveRange(entities);
            _context.SaveChanges();
        }

        public TEntity Get(Guid id)
        {
            return _context.Find<TEntity>(id);
        }

        public ICollection<TEntity> GetAll(ICollection<Guid>? ids)
        {
            ICollection<TEntity> list = new List<TEntity>();
            if(ids != null)
            {
                foreach (var id in ids)
                {
                    list.Add(Get(id));
                }
            }
            else
            {
                list = _context.Set<TEntity>().Where(t => t.Id != Guid.Empty).ToList();
            }
            return list;
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.UpdateRange(entities);
            _context.SaveChanges();
        }
    }
}
