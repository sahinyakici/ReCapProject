using Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Entities.Concretes;


public class Customers : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string CompanyName { get; set; }
}