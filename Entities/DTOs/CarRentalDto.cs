namespace Entities.DTOs;

public class CarRentalDto
{
    public int Id { get; set; }
    public string BrandName { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
}