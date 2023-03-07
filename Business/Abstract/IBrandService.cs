using Entities.Concretes;

namespace Business.Abstract;

public interface IBrandService
{
    List<Brand> GetAllBrands();
    List<Brand> GetBrandById(int brandId);
    void Insert(Brand brand);
    void Update(Brand Brand);
    void Delete(Brand Brand);
}