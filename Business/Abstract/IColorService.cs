using Entities.Concretes;

namespace Business.Abstract;

public interface IColorService
{
    List<Color> GetAllColors();
    List<Color> GetColorById(int colorId);
    void Insert(Color color);
    void Update(Color color);
    void Delete(Color color);
}