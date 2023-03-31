using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.File;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concretes;

public class CarImageManager : ICarImageService
{
    private readonly ICarImagesDal _carImagesDal;
    private readonly IFileService _fileManager;

    public CarImageManager(ICarImagesDal carImagesDal, IFileService fileManager)
    {
        _carImagesDal = carImagesDal;
        _fileManager = fileManager;
    }

    public IDataResult<List<CarImage>> GetAllCarImage()
    {
        return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll());
    }

    public IDataResult<List<CarImage>> GetCarImageById(string imagePath)
    {
        return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(i => i.ImagePath == imagePath));
    }

    public IDataResult<List<CarImage>> GetCarImageByCarId(int carId)
    {
        return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(i => i.CarId == carId));
    }

    public IResult AddCarImage(int carId, string path)
    {
        var result = BusinessRules.Run(CheckCarShouldHaveMaxFiveImages(carId));
        if (result != null) return result;
        CarImage carImage = new CarImage();
        carImage.CarId = carId;
        carImage.ImagePath = _fileManager.UploadWithGuid(path, Paths.Images).Message;
        carImage.Date = DateTime.Now;
        _carImagesDal.Add(carImage);
        return new SuccessResult(Messages.ImageAdded);
    }

    public IResult UpdateCarImage(int carImageId, string path)
    {
        var carImage = _carImagesDal.Get(c => c.Id == carImageId);
        var fileName = carImage.ImagePath;
        _fileManager.Delete(Paths.Images + fileName);
        _fileManager.Upload(path, Paths.Images, fileName);
        return new SuccessResult(Messages.ImageUpdated);
    }

    public IResult DeleteCarImage(CarImage carImage)
    {
        _fileManager.Delete(carImage.ImagePath);
        _carImagesDal.Delete(carImage);
        return new SuccessResult(Messages.ImageDeleted);
    }

    private IResult CheckCarShouldHaveMaxFiveImages(int carId)
    {
        var result = _carImagesDal.GetAll(ima => ima.CarId == carId).Count;
        if (result < 5)
            return new SuccessResult();
        return new ErrorResult(Messages.CarHaveMaxImagesError);
    }
}