using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework;

public class EfBrandDal : IBrandDal
{
    public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
        }
    }

    public Brand Get(Expression<Func<Brand, bool>> filter)
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            return context.Set<Brand>().SingleOrDefault(filter);
        }
    }

    public void Add(Brand entity)
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Delete(Brand entity)
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public void Update(Brand entity)
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}