using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public IDataResult<List<Brand>> GetAllBrands()
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
    }

    public IDataResult<List<Brand>> GetBrandById(int brandId)
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => brandId == b.Id));
    }

    [ValidationAspect(typeof(BrandValidator))]
    public IResult Insert(Brand brand)
    {
        _brandDal.Add(brand);
        return new SuccessResult(Messages.BrandAdded);
    }

    [ValidationAspect(typeof(BrandValidator))]
    public IResult Update(Brand brand)
    {
        _brandDal.Update(brand);
        return new SuccessResult(Messages.BrandUpdated);
    }

    public IResult Delete(Brand brand)
    {
        _brandDal.Delete(brand);
        return new SuccessResult(Messages.BrandRemoved);
    }
}