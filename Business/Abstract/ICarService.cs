using Entities.Concretes;

namespace Business.Abstract;

public interface ICarService
{
    List<Car> GetCarsByBrandId(int brandId);
    List<Car> GetCarsByColorId(int colorId);
    List<Car> GetAll();
}