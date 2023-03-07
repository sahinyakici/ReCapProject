using Entities.Concretes;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICarService
{
    List<Car> GetCarsByBrandId(int brandId);
    List<Car> GetCarsByColorId(int colorId);
    List<Car> GetAll();
    void Update(Car car);
    void Delete(Car car);
    List<CarDetailDto> GetCarDetails();
}