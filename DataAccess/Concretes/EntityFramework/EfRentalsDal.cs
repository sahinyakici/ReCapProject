using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfRentalsDal : EfEntityRepositoryBase<Rentals, SqlServerContext>, IRentalsDal
{
}