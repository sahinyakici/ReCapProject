﻿using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;

//AllCarMethodsTest();
//AllBrandMethodsTest();
//AllColorMethodsTest();
InsertItems();
WriteCars();

void AllCarMethodsTest()
{
    void WriteAllElements(List<Car> cars)
    {
        foreach (Car car in cars)
        {
            Console.WriteLine("{0} --- {1} --- {2} --- {3} --- {4} --- {5}", car.Id, car.BrandId, car.ColorId,
                car.ModelYear,
                car.DailyPrice, car.Description);
        }
    }

    {
        CarManager carManager = new CarManager(new EfCarDal());
        Car myCar = new Car
            { BrandId = 1, Description = "BMW", ColorId = 4, DailyPrice = 2566, ModelYear = "2023", CarName = "BMW" };
        Car wrongCar = new Car
            { BrandId = 5, Description = "BMW", ColorId = 1, DailyPrice = 2566, ModelYear = "2023", CarName = "BM" };
        Car newCar = new Car
        {
            Id = 1, BrandId = 5, Description = "UPDATED", ColorId = 1, DailyPrice = 2977, ModelYear = "2023",
            CarName = "Mercedes"
        };
        List<Car> cars = new List<Car>();
        carManager.Add(myCar);
        cars = carManager.GetAll();
        Console.WriteLine("--- I added a car ---");
        WriteAllElements(cars);
        /*carManager.Add(newCar);
        cars = carManager.GetAll();
        Console.WriteLine("--- I added a car ---");
        WriteAllElements(cars);
        carManager.Delete(newCar);
        cars = carManager.GetAll();
        Console.WriteLine("--- I deleted a car ---");
        WriteAllElements(cars);*/
        carManager.Add(wrongCar);
        Console.WriteLine("--- I tried add a wrong car ---");
        cars = carManager.GetCarsByBrandId(5);
        Console.WriteLine("--- I filtered cars by brand id ---");
        WriteAllElements(cars);
        cars = carManager.GetCarsByColorId(4);
        Console.WriteLine("--- I filtered cars by color id ---");
        WriteAllElements(cars);
    }
}

void AllBrandMethodsTest()
{
    void WriteAllElements(List<Brand> brands)
    {
        foreach (Brand brand in brands)
        {
            Console.WriteLine("{0} --- {1}", brand.Id, brand.Name);
        }
    }

    BrandManager brandManager = new BrandManager(new EfBrandDal());
    brandManager.Insert(new Brand { Id = 1, Name = "Mercedes" });
    brandManager.Insert(new Brand { Id = 2, Name = "BMW" });
    Brand newBrand = new Brand { Id = 1, Name = "Peugeot" };
    List<Brand> brands = brandManager.GetAllBrands();
    Console.WriteLine("---ALL ELEMENTS ADDED---");
    WriteAllElements(brands);

    brandManager.Update(newBrand);
    brands = brandManager.GetAllBrands();
    Console.WriteLine("---Updated 1 element---");
    WriteAllElements(brands);

    Console.WriteLine("---I test id---");
    List<Brand> test = brandManager.GetBrandById(2);
    WriteAllElements(test);

    brandManager.Delete(newBrand);
    Console.WriteLine("---I deleted 1 element---");
    brands = brandManager.GetAllBrands();
    WriteAllElements(brands);
}

void AllColorMethodsTest()
{
    void WriteAllElements(List<Color> colors)
    {
        foreach (Color color in colors)
        {
            Console.WriteLine("{0} --- {1}", color.Id, color.Name);
        }
    }

    ColorManager colorManager = new ColorManager(new EfColorDal());
    colorManager.Insert(new Color { Id = 1, Name = "Siyah" });
    colorManager.Insert(new Color { Id = 2, Name = "Beyaz" });
    Color newColor = new Color { Id = 1, Name = "Mavi" };
    List<Color> colors = colorManager.GetAllColors();
    Console.WriteLine("---ALL COLORS ADDED---");
    WriteAllElements(colors);

    colorManager.Update(newColor);
    colors = colorManager.GetAllColors();
    Console.WriteLine("---Updated 1 color---");
    WriteAllElements(colors);

    Console.WriteLine("---I test id---");
    List<Color> test = colorManager.GetColorById(2);
    WriteAllElements(test);

    colorManager.Delete(newColor);
    Console.WriteLine("---I deleted 1 element---");
    colors = colorManager.GetAllColors();
    WriteAllElements(colors);
}

void InsertItems()
{
    CarManager carManager = new CarManager(new EfCarDal());
    ColorManager colorManager = new ColorManager(new EfColorDal());
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    colorManager.Insert(new Color { Id = 5, Name = "Beyaz" });
    brandManager.Insert(new Brand { Id = 5, Name = "Mercedes" });
    carManager.Add(new Car
    {
        BrandId = 5, CarName = "Test", ColorId = 5, Description = "Test Car", ModelYear = "2023", DailyPrice = 2025
    });
}

void WriteCars()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var carDetail in carManager.GetCarDetails())
    {
        Console.WriteLine("{0} --- {1} --- {2} --- {3}", carDetail.CarName, carDetail.BrandName, carDetail.ColorName,
            carDetail.DailyPrice);
    }
}