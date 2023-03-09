using Core.Utilities.Results.Abstract;
using Entities.Concretes;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICarService
{
    IDataResult<List<Car>> GetCarsByBrandId(int brandId);
    IDataResult<List<Car>> GetCarsByColorId(int colorId);
    IDataResult<List<Car>> GetAll();
    IResult Update(Car car);
    IResult Delete(Car car);
    IResult Add(Car car);
    IDataResult<List<CarDetailDto>> GetCarDetails();
}