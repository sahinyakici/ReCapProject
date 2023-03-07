﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concretes;
using Entities.DTOs;

namespace Business.Concretes;

public class CarManager : ICarService
{
    private ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }

    public List<Car> GetCarsByBrandId(int brandId)
    {
        return _carDal.GetAll(c => c.BrandId == brandId);
    }

    public List<Car> GetCarsByColorId(int colorId)
    {
        return _carDal.GetAll(c => c.ColorId == colorId);
    }

    public List<Car> GetAll()
    {
        return _carDal.GetAll();
    }

    public void Update(Car car)
    {
        _carDal.Update(car);
    }

    public void Delete(Car car)
    {
        _carDal.Delete(car);
    }

    public List<CarDetailDto> GetCarDetails()
    {
        return _carDal.GetCarDetails();
    }

    public void Add(Car car)
    {
        if (car.DailyPrice > 0 && car.CarName.Length > 2)
        {
            _carDal.Add(car);
        }
        else
        {
            Console.WriteLine
                ("Daily price should bigger than 0 and car name length should min 3 charecters");
        }
    }
}