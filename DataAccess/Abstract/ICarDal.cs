using System.Linq.Expressions;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface ICarDal : IEntityRepository<Car>
{
}