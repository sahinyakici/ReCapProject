using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concretes;

public class RentalsManager : IRentalsService
{
    private readonly IRentalsDal _rentalsDal;

    public RentalsManager(IRentalsDal rentalsDal)
    {
        _rentalsDal = rentalsDal;
    }

    public IDataResult<List<Rentals>> GetAll()
    {
        return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll());
    }

    public IDataResult<List<Rentals>> GetByRentalId(int rentalId)
    {
        return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll(r => rentalId == r.Id));
    }

    [ValidationAspect(typeof(RentalValidator))]
    public IResult Add(Rentals rental)
    {
        if (rental.ReturnDate == null)
            return new ErrorResult(Messages.RentalFailed);
        _rentalsDal.Add(rental);
        return new SuccessResult(Messages.RentalAdded);
    }

    public IResult Delete(Rentals rental)
    {
        _rentalsDal.Delete(rental);
        return new SuccessResult(Messages.RentalDeleted);
    }

    [ValidationAspect(typeof(RentalValidator))]
    public IResult Update(Rentals rental)
    {
        _rentalsDal.Update(rental);
        return new SuccessResult(Messages.RentalUpdated);
    }
}