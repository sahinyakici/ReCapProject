using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concretes;

public class CustomerManager : ICustomersService
{
    private ICustomersDal _customerDal;

    public CustomerManager(ICustomersDal customerDal)
    {
        _customerDal = customerDal;
    }

    public IDataResult<List<Customers>> GetAll()
    {
        return new SuccessDataResult<List<Customers>>(_customerDal.GetAll());
    }

    public IDataResult<List<Customers>> GetByCustomerId(int customerId)
    {
        return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(c => c.UserId == customerId));
    }

    public IResult Add(Customers customer)
    {
        _customerDal.Add(customer);
        return new SuccessResult(Messages.CustomerAdded);
    }

    public IResult Delete(Customers customer)
    {
        _customerDal.Delete(customer);
        return new SuccessResult(Messages.CustomerDeleted);
    }

    public IResult Update(Customers customer)
    {
        _customerDal.Update(customer);
        return new SuccessResult(Messages.CustomerUpdated);
    }
}