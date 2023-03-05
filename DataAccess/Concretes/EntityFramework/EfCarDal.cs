using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework;

public class EfCarDal : ICarDal
{
    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
        }
        /*using (PostgreSqlContext context = new PostgreSqlContext())
        {
            return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
        }*/
    }

    public Car Get(Expression<Func<Car, bool>> filter)
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            return context.Set<Car>().SingleOrDefault(filter);
        }
       /* using (PostgreSqlContext context = new PostgreSqlContext())
        {
            return context.Set<Car>().SingleOrDefault(filter);
        }*/
    }

    public void Add(Car entity)
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }/*
        using (PostgreSqlContext context = new PostgreSqlContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }*/
    }

    public void Delete(Car entity)
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }/*
        using (PostgreSqlContext context = new PostgreSqlContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }*/
    }

    public void Update(Car entity)
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }/*
        using (PostgreSqlContext context = new PostgreSqlContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }*/
    }
}