using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public List<Brand> GetAllBrands()
    {
        return _brandDal.GetAll();
    }

    public List<Brand> GetBrandById(int brandId)
    {
        return _brandDal.GetAll(b => brandId == b.Id);
    }

    public void Insert(Brand brand)
    {
        _brandDal.Add(brand);
    }

    public void Update(Brand brand)
    {
        _brandDal.Update(brand);
    }

    public void Delete(Brand brand)
    {
        _brandDal.Delete(brand);
    }
}