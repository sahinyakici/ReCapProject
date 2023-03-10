using Core.Utilities.Results.Abstract;
using Entities.Concretes;

namespace Business.Abstract;

public interface IRentalsService
{
    IDataResult<List<Rentals>> GetAll();
    IDataResult<List<Rentals>> GetByRentalId(int rentalId);
    IResult Add(Rentals rental);
    IResult Delete(Rentals rental);
    IResult Update(Rentals rental);
}