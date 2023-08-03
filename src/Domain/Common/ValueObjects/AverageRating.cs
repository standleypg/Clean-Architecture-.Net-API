using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common.Models;

namespace Domain.Common.ValueObjects;

public class AverageRating : ValueObject
{
    public AverageRating(double value, int numRatings)
    {
        NumRatings = numRatings;
        Value = value;
    }
    public int NumRatings { get; private set; }
    public double Value { get; private set; }

    public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
    {
        return new AverageRating(rating, numRatings);
    }

    public void AddNewRating(Rating rating)
    {
        Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    internal void RemoveRating(Rating rating)
    {
        Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
    }

}
