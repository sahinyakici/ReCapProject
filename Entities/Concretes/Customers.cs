using Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Entities.Concretes;

[Keyless]
public class Customers : IEntity
{
    public int UserId { get; set; }
    public string CompanyName { get; set; }
}