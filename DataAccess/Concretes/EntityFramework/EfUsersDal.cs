using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfUsersDal : EfEntityRepositoryBase<Users, SqlServerContext>, IUsersDal
{
}