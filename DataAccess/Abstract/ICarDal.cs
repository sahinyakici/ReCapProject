using Entities.Concretes;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface ICarDal : IEntityRepository<Car>
{
    List<CarDetailDto> GetCarDetails();
    List<CarDetailDto> GetDetailsByBrandId(int brandId);
    List<CarDetailDto> GetDetailsByColorId(int colorId);
}