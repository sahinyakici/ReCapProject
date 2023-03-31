using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using Entities.Concretes;
using Entities.DTOs;

namespace DataAccess.Concretes.EntityFramework;

public class EfCarDal : EfEntityRepositoryBase<Car, SqlServerContext>, ICarDal
{
    public List<CarDetailDto> GetCarDetails()
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            var result = from car in context.Cars
                join brand in context.Brand on car.BrandId equals brand.Id
                join color in context.Colors on car.ColorId equals color.Id
                join carImage in context.CarImages on car.Id equals carImage.CarId into Images
                from image in Images.DefaultIfEmpty()
                group new { car, brand, color, image } by car.Id
                into carGroup
                select new CarDetailDto
                {
                    Id = carGroup.First().car.Id,
                    CarName = carGroup.First().car.CarName ?? "",
                    BrandName = carGroup.First().brand.Name ?? "",
                    ColorName = carGroup.First().color.Name ?? "",
                    DailyPrice = carGroup.First().car.DailyPrice,
                    CarImage = carGroup.Select(c => c.image == null ? "default.png" : c.image.ImagePath).ToList()
                };
            return result.ToList();
        }
    }

    public List<CarDetailDto> GetDetailsByBrandId(int brandId)
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            var result = from car in context.Cars
                where car.BrandId == brandId
                join brand in context.Brand on car.BrandId equals brand.Id
                join color in context.Colors on car.ColorId equals color.Id
                join carImage in context.CarImages on car.Id equals carImage.CarId into Images
                from image in Images.DefaultIfEmpty()
                group new { car, brand, color, image } by car.Id
                into carGroup
                select new CarDetailDto
                {
                    Id = carGroup.First().car.Id,
                    CarName = carGroup.First().car.CarName ?? "",
                    BrandName = carGroup.First().brand.Name ?? "",
                    ColorName = carGroup.First().color.Name ?? "",
                    DailyPrice = carGroup.First().car.DailyPrice,
                    CarImage = carGroup.Select(c => c.image == null ? "default.png" : c.image.ImagePath).ToList()
                };
            return result.ToList();
        }
    }

    public List<CarDetailDto> GetDetailsByColorId(int colorId)
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            var result = from car in context.Cars
                where car.ColorId == colorId
                join brand in context.Brand on car.BrandId equals brand.Id
                join color in context.Colors on car.ColorId equals color.Id
                join carImage in context.CarImages on car.Id equals carImage.CarId into Images
                from image in Images.DefaultIfEmpty()
                group new { car, brand, color, image } by car.Id
                into carGroup
                select new CarDetailDto
                {
                    Id = carGroup.First().car.Id,
                    CarName = carGroup.First().car.CarName ?? "",
                    BrandName = carGroup.First().brand.Name ?? "",
                    ColorName = carGroup.First().color.Name ?? "",
                    DailyPrice = carGroup.First().car.DailyPrice,
                    CarImage = carGroup.Select(c => c.image == null ? "default.png" : c.image.ImagePath).ToList()
                };
            return result.ToList();
        }
    }

    public List<CarDetailDto> GetCarDetailsById(int carId)
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            var result = from car in context.Cars
                where car.Id == carId
                join brand in context.Brand on car.BrandId equals brand.Id
                join color in context.Colors on car.ColorId equals color.Id
                join carImage in context.CarImages on car.Id equals carImage.CarId into Images
                from image in Images.DefaultIfEmpty()
                group new { car, brand, color, image } by car.Id
                into carGroup
                select new CarDetailDto
                {
                    Id = carGroup.First().car.Id,
                    ModelYear = carGroup.First().car.ModelYear,
                    Description = carGroup.First().car.Description,
                    CarName = carGroup.First().car.CarName ?? "",
                    BrandName = carGroup.First().brand.Name ?? "",
                    ColorName = carGroup.First().color.Name ?? "",
                    DailyPrice = carGroup.First().car.DailyPrice,
                    CarImage = carGroup.Select(c => c.image == null ? "default.png" : c.image.ImagePath).ToList()
                };
            return result.ToList();
        }
    }
}