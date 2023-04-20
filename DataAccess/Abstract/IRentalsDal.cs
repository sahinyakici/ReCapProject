using Entities.Concretes;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface IRentalsDal : IEntityRepository<Rentals>
{
    List<CarRentalDto> GetCarRentalDetails();
    List<CarRentalDto> GetCarRentalDetailsWithCarId(int carId);
}