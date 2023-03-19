﻿using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Business;

public static class BusinessRules
{
    public static IResult Run(params IResult[] logics)
    {
        foreach (var logic in logics)
        {
            if (!logic.Success)
                return logic;
        }

        return null;
    }
}