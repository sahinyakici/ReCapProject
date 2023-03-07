using Business.Abstract;
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

    public List<Color> GetAllColors()
    {
        return _colorDal.GetAll();
    }

    public List<Color> GetColorById(int colorId)
    {
        return _colorDal.GetAll(c => colorId == c.Id);
    }

    public void Insert(Color color)
    {
        _colorDal.Add(color);
    }

    public void Update(Color color)
    {
        _colorDal.Update(color);
    }

    public void Delete(Color color)
    {
        _colorDal.Delete(color);
    }
}