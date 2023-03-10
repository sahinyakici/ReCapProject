using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concretes;

public class UserManager : IUsersService
{
    private IUsersDal _usersDal;

    public UserManager(IUsersDal usersDal)
    {
        _usersDal = usersDal;
    }

    public IDataResult<List<Users>> GetAll()
    {
        return new SuccessDataResult<List<Users>>(_usersDal.GetAll());
    }

    public IDataResult<List<Users>> GetUserById(int userId)
    {
        return new SuccessDataResult<List<Users>>(_usersDal.GetAll(u => userId == u.Id));
    }

    public IResult Add(Users user)
    {
        _usersDal.Add(user);
        return new SuccessResult(Messages.UserAdded);
    }

    public IResult Delete(Users user)
    {
        _usersDal.Delete(user);
        return new SuccessResult(Messages.UserDeleted);
    }

    public IResult Update(Users user)
    {
        _usersDal.Update(user);
        return new SuccessResult(Messages.UserUpdated);
    }
}