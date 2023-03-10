using Core.Utilities.Results.Abstract;
using Entities.Concretes;

namespace Business.Abstract;

public interface IUsersService
{
    IDataResult<List<Users>> GetAll();
    IDataResult<List<Users>> GetUserById(int userId);
    IResult Add(Users user);
    IResult Delete(Users user);
    IResult Update(Users user);
}