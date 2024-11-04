﻿using InstitutionManagmentSystem.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryWithUOW.Core.Interfaces;
using System.Linq.Expressions;


namespace RepositoryWithUWO.EF.Repositories;

public class BaseRepository<T>(AppDbContext appDbContext) : IBaseRepository<T> where T : class
{
    private AppDbContext _appDbContext  = appDbContext;

    public async Task<IEnumerable<T>> GetAllAsync(string[] includes = null)
    {
        IQueryable<T> values = _appDbContext.Set<T>();

        if (includes != null)
        {
            foreach (var include in includes)
            {
                values = values.Include(include);
            }
        }

        return await values.ToListAsync();
    }

    public async Task< T> Find(Expression<Func<T, bool>> predicate, string[] includes = null)
    {
        IQueryable<T> values = _appDbContext.Set<T>();

        if (includes != null)
        {
            foreach (var include in includes)
            {
                values = values.Include(include);
            }
        }
        return await values.SingleOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate, string[] includes = null)
    {
        IQueryable<T> values =  _appDbContext.Set<T>();

        if (includes != null)
        {
            foreach (var include in includes)
            {
                values = values.Include(include);
            }
        }
        return await values.Where(predicate).ToListAsync();
    }

    public async Task Add(T item) => await _appDbContext.Set<T>().AddAsync(item);

    public async Task Update(T item) => _appDbContext.Set<T>().Update(item);

    public async Task Delete(int Id) =>   _appDbContext.Remove(await _appDbContext.FindAsync<T>(Id));

}
