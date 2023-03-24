using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concretes;

public class CustomerManager : ICustomersService
{
    private readonly ICustomersDal _customerDal;

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

    [ValidationAspect(typeof(CustomerValidator))]
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

    [ValidationAspect(typeof(CustomerValidator))]
    public IResult Update(Customers customer)
    {
        _customerDal.Update(customer);
        return new SuccessResult(Messages.CustomerUpdated);
    }
}