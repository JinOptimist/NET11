﻿using DALInterfaces.DataModels;
using DALInterfaces.Models;
using DALInterfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DALEfDB.Repositories
{
    public abstract class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
    {
        protected WebContext _context;
        protected DbSet<DbModel> _dbSet;

        public BaseRepository(WebContext context)
        {
            _context = context;
            _dbSet = context.Set<DbModel>();
        }

        public int Count()
            => _dbSet.Count();

        public virtual DbModel Get(int id)
            => _dbSet.First(x => x.Id == id);

        public virtual IEnumerable<DbModel> GetAll()
            => _dbSet.ToList();

        public virtual void Remove(int id)
        {
            _dbSet.Remove(Get(id));
            _context.SaveChanges();
        }

        public virtual void Save(DbModel model)
        {
            _dbSet.Add(model);
            _context.SaveChanges();
        }

        public virtual void Update(DbModel model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }

        public virtual void SaveRange(IEnumerable<DbModel> models)
        {
            _dbSet.AddRange(models);
            _context.SaveChanges();
        }

        protected virtual IQueryable<DbModel> GetDbSetWithIncludeForPaginator()
        {
            return _dbSet;
        }

        public virtual PaginatorDataModel<DataModelTemplate> GetPaginatorDataModel<DataModelTemplate>(
            Func<DbModel, DataModelTemplate> map,
            int page,
            int perPage)
        {
            var count = _dbSet.Count();

            var items = GetDbSetWithIncludeForPaginator()
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .Select(map)
                .ToList();

            return new PaginatorDataModel<DataModelTemplate>
            {
                Count = count,
                Page = page,
                PerPage = perPage,
                Items = items
            };
        }

        public DbModel GetLast()
         => _dbSet
            .OrderBy(x => x.Id)
            .Last();
        public bool Any()
         => _dbSet
            .Any();

    }
}
