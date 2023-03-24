using Entities.Abstract.Concrete;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface IUserDal : IEntityRepository<User>
{
    List<OperationClaim> GetClaims(User user);
}