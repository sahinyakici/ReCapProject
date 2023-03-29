﻿using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using Entities.Concretes;
using Entities.DTOs;

namespace DataAccess.Concretes.EntityFramework;

public class EfRentalsDal : EfEntityRepositoryBase<Rentals, SqlServerContext>, IRentalsDal
{
    public List<CarRentalDto> GetCarRentalDetails()
    {
        using (SqlServerContext context = new SqlServerContext())
        {
            var result = from rental in context.Rentals
                join car in context.Cars on rental.CarId equals car.Id
                join customer in context.Customers on rental.CustomerId equals customer.Id
                join brand in context.Brand on car.BrandId equals brand.Id
                join user in context.Users on customer.UserId equals user.Id
                select new CarRentalDto()
                {
                    Id = rental.Id,
                    BrandName = brand.Name,
                    CustomerFirstName = user.FirstName,
                    CustomerLastName = user.LastName,
                    RentDate = rental.RentDate,
                    ReturnDate = rental.RentDate
                };
            return result.ToList();
        }
    }
}