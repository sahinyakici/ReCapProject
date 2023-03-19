using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfCarImagesDal : EfEntityRepositoryBase<CarImage, SqlServerContext>, ICarImagesDal
{
}