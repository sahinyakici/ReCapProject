﻿using Entities.Abstract.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework;

public class SqlServerContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=SAHIN;Database=ReCap;Trusted_Connection=true;Encrypt=False");
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Rentals> Rentals { get; set; }
    public DbSet<CarImage> CarImages { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
}