namespace Entities.DTOs;

public class CarRentalDto
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}