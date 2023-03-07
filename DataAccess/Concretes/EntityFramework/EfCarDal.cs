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
                select new CarDetailDto
                {
                    BrandName = brand.Name, ColorName = color.Name, CarName = car.CarName, DailyPrice = car.DailyPrice
                };
            return result.ToList();
        }
    }
}