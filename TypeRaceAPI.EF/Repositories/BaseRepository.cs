﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.Consts;
using TypeRaceAPI.Core.Interfaces;

namespace TypeRaceAPI.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T? Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<T?> AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
            return entities;
        }

        public IEnumerable<T?> FindAll(Expression<Func<T, bool>> predicate, string[]? includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.Where(predicate).ToList();
        }

        public IEnumerable<T?> FindAll(Expression<Func<T, bool>> predicate,
            int? skip = null, int? take = null, Expression<Func<T, object>>? orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _dbSet.Where(predicate);
            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }
            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }
            return query.ToList();
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, string[]? includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync(predicate) as T;
        }

        public T? Get(int id)
        {
            return _dbSet.Find(id) as T;
        }

        //public T? Get(Expression<Func<T, bool>> predicate)
        //{
        //    IQueryable<T> query = _context.Set<T>().Where(predicate);
        //    return query.FirstOrDefault() as T;
        //}

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

    }
}
