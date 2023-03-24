using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using Entities.Abstract.Concrete;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, SqlServerContext>, IUserDal
{
    public List<OperationClaim> GetClaims(User user)
    {
        using (var context = new SqlServerContext())
        {
            var result = from operationClaim in context.OperationClaims
                join userOperationClaim in context.UserOperationClaims
                    on operationClaim.Id equals userOperationClaim.OperationClaimId
                where userOperationClaim.UserId == user.Id
                select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}