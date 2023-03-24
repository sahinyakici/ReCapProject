using Core.Utilities.Results.Abstract;
using Entities.Concretes;

namespace Business.Abstract;

public interface ICarImageService
{
    IDataResult<List<CarImage>> GetAllCarImage();
    IDataResult<List<CarImage>> GetCarImageById(string imagePath);
    IDataResult<List<CarImage>> GetCarImageByCarId(int carId);
    IResult AddCarImage(CarImage carImage, string path);
    IResult UpdateCarImage(int carImageId, string path);
    IResult DeleteCarImage(CarImage carImage);
}