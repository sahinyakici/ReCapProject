using Core.Utilities.Results.Abstract;
using Entities.Concretes;

namespace Business.Abstract;

public interface IColorService
{
    IDataResult<List<Color>> GetAllColors();
    IDataResult<List<Color>> GetColorById(int colorId);
    IResult Insert(Color color);
    IResult Update(Color color);
    IResult Delete(Color color);
}