using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common.Models;

namespace Domain.Host.ValueObjects;

public class HostId : ValueObject
{
    private HostId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }
    public static HostId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static HostId Create(Guid hostId)
    {
        return new(hostId);
    }
}
