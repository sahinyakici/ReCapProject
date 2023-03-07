using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfBrandDal : EfEntityRepositoryBase<Brand, SqlServerContext>, IBrandDal
{
}