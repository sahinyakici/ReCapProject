﻿using Entities.Abstract;

namespace Entities.Concretes;

public class Color : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}