using Core.Utilities.Results.Abstract;
using Entities.Concretes;

namespace Business.Abstract;

public interface ICustomersService
{
    IDataResult<List<Customers>> GetAll();
    IDataResult<List<Customers>> GetByCustomerId(int customerId);
    IResult Add(Customers customer);
    IResult Delete(Customers customer);
    IResult Update(Customers customer);
}