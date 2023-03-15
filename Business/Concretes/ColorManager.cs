using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concretes;

public class ColorManager : IColorService
{
    private IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }

    public IDataResult<List<Color>> GetAllColors()
    {
        return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
    }

    public IDataResult<List<Color>> GetColorById(int colorId)
    {
        return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => colorId == c.Id));
    }

    [ValidationAspect(typeof(ColorValidator))]
    public IResult Insert(Color color)
    {
        _colorDal.Add(color);
        return new SuccessResult(Messages.ColorAdded);
    }

    [ValidationAspect(typeof(ColorValidator))]
    public IResult Update(Color color)
    {
        _colorDal.Update(color);
        return new SuccessResult(Messages.ColorUpdated);
    }

    public IResult Delete(Color color)
    {
        _colorDal.Delete(color);
        return new SuccessResult(Messages.ColorRemoved);
    }
}