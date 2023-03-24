using Core.Utilities.Results.Abstract;
using Entities.Abstract.Concrete;
using Entities.Concretes;

namespace Business.Abstract;

public interface IUserService
{
    IDataResult<List<User>> GetAll();
    IDataResult<List<User>> GetUserById(int userId);
    IResult Add(User user);
    IResult Delete(User user);
    IResult Update(User user);
    IDataResult<List<OperationClaim>> GetClaims(User user);
    IDataResult<User> GetByMail(string email);
}