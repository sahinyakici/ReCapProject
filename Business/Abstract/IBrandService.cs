using Core.Utilities.Results.Abstract;
using Entities.Concretes;

namespace Business.Abstract;

public interface IBrandService
{
    IDataResult<List<Brand>> GetAllBrands();
    IDataResult<List<Brand>> GetBrandById(int brandId);
    IResult Insert(Brand brand);
    IResult Update(Brand brand);
    IResult Delete(Brand brand);
}