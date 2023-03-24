using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstract;
using Entities.Abstract.Concrete;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserDal _usersDal;

    public UserManager(IUserDal usersDal)
    {
        _usersDal = usersDal;
    }

    public IDataResult<List<User>> GetAll()
    {
        return new SuccessDataResult<List<User>>(_usersDal.GetAll());
    }

    public IDataResult<List<User>> GetUserById(int userId)
    {
        return new SuccessDataResult<List<User>>(_usersDal.GetAll(u => userId == u.Id));
    }

    [ValidationAspect(typeof(UserValidator))]
    public IResult Add(User user)
    {
        _usersDal.Add(user);
        return new SuccessResult(Messages.UserAdded);
    }

    public IResult Delete(User user)
    {
        _usersDal.Delete(user);
        return new SuccessResult(Messages.UserDeleted);
    }

    [ValidationAspect(typeof(UserValidator))]
    public IResult Update(User user)
    {
        _usersDal.Update(user);
        return new SuccessResult(Messages.UserUpdated);
    }

    public IDataResult<List<OperationClaim>> GetClaims(User user)
    {
        return new SuccessDataResult<List<OperationClaim>>(_usersDal.GetClaims(user));
    }

    public IDataResult<User> GetByMail(string email)
    {
        return new SuccessDataResult<User>(_usersDal.Get(u => u.Email == email));
    }
}