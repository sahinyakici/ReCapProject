using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;

CarManager carManager = new CarManager(new EfCarDal());
Car myCar = new Car
    { BrandId = 1, Description = "BMW", ColorId = 4, DailyPrice = 2566, ModelYear = "2023", CarName = "BMW" };
Car wrongCar = new Car
    { BrandId = 5, Description = "BMW", ColorId = 1, DailyPrice = 2566, ModelYear = "2023", CarName = "BM" };
Car newCar = new Car
{
    BrandId = 5, Description = "Mercedes", ColorId = 1, DailyPrice = 2977, ModelYear = "2023",
    CarName = "Mercedes"
};
List<Car> cars = new List<Car>();
carManager.Add(myCar);
cars = carManager.GetAll();
Console.WriteLine("--- I added a car ---");
WriteAllElements(cars);
carManager.Add(newCar);
cars = carManager.GetAll();
Console.WriteLine("--- I added a car ---");
WriteAllElements(cars);
cars = carManager.GetCarsByBrandId(5);
Console.WriteLine("--- I filtered cars by brand id ---");
WriteAllElements(cars);
cars = carManager.GetCarsByColorId(4);
Console.WriteLine("--- I filtered cars by color id ---");
WriteAllElements(cars);

void WriteAllElements(List<Car> cars)
{
    foreach (Car car in cars)
    {
        Console.WriteLine("{0} --- {1} --- {2} --- {3} --- {4} --- {5}", car.Id, car.BrandId, car.ColorId,
            car.ModelYear,
            car.DailyPrice, car.Description);
    }
}