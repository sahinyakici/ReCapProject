using DataAccess.Abstract;
using DataAccess.Concretes.InMemory;
using Entities.Concretes;

ICarDal carDal = new InMemoryCarDal();
Car myCar = new Car { Id = 6, BrandId = 1, Description = "BMW", ColorId = 1, DailyPrice = 2566, ModelYear = "2023" };
Car newCar = new Car
    { Id = 6, BrandId = 1, Description = "BMW updated", ColorId = 1, DailyPrice = 2977, ModelYear = "2023" };
carDal.Add(myCar);
Console.WriteLine("--- I added a car ---");
WriteAllElements(carDal);
carDal.Update(newCar);
Console.WriteLine("--- I updated a car ---");
WriteAllElements(carDal);
carDal.Delete(newCar);
Console.WriteLine("--- I deleted a car ---");
WriteAllElements(carDal);

void WriteAllElements(ICarDal carDal1)
{
    List<Car> cars = carDal1.GetAll();
    foreach (Car car in cars)
    {
        Console.WriteLine("{0} --- {1} --- {2} --- {3} --- {4} --- {5}", car.Id, car.BrandId, car.ColorId,
            car.ModelYear,
            car.DailyPrice, car.Description);
    }
}