using DataAccess.Abstract;
using Entities.Concretes;

namespace DataAccess.Concretes.InMemory;

public class InMemoryCarDal : ICarDal
{
    private List<Car> _cars;

    public InMemoryCarDal()
    {
        _cars = new List<Car>
        {
            new Car
            {
                Id = 1, BrandId = 2, ColorId = 1, DailyPrice = 9800, ModelYear = "2022", Description = "Mercedes"
            },
            new Car { Id = 2, BrandId = 1, ColorId = 8, DailyPrice = 9700, ModelYear = "2019", Description = "BMW" },
            new Car
            {
                Id = 3, BrandId = 3, ColorId = 9, DailyPrice = 6500, ModelYear = "2023", Description = "Peugeot"
            },
            new Car { Id = 4, BrandId = 4, ColorId = 4, DailyPrice = 3200, ModelYear = "2016", Description = "Fiat" },
            new Car
            {
                Id = 5, BrandId = 2, ColorId = 2, DailyPrice = 12000, ModelYear = "2023", Description = "Mercedes"
            },
        };
    }

    public List<Car> GetAll()
    {
        return _cars;
    }

    public Car GetById(int id)
    {
        return (Car)_cars.Where(c => c.Id == id);
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Update(Car car)
    {
        Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
        carToUpdate.ColorId = car.ColorId;
        carToUpdate.Description = car.Description;
        carToUpdate.ModelYear = car.ModelYear;
        carToUpdate.DailyPrice = car.DailyPrice;
        carToUpdate.BrandId = car.BrandId;
    }

    public void Delete(Car car)
    {
        Car carToDelete = _cars.SingleOrDefault(c => car.Id == c.Id);
        _cars.Remove(carToDelete);
    }
}