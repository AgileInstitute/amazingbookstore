using System;
using System.ComponentModel;
using System.Data.Common;

namespace AmazingBookstore;

public class Money : IEquatable<Money>
{
    private readonly long _normalizedDollars;

    public Money(long normalizedDollars)
    {
        _normalizedDollars = normalizedDollars;
    }

    public Money(long dollars, long cents)
    {
        if (cents >= 100) throw new Exception("cents can not be greater than 99");

        _normalizedDollars = (dollars * 100) + cents;
    }

    public bool Equals(Money? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _normalizedDollars == other._normalizedDollars;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Money) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_normalizedDollars);
    }

    public override string ToString()
    {
        return $"${_normalizedDollars / 100}.{_normalizedDollars % 100:00}";
    }

    public static Money operator +(Money money1, Money money2)
    {
        return new Money(money1._normalizedDollars + money2._normalizedDollars);
    }

    public static Money operator *(Money money, long multiple)
    {
        return new Money(money._normalizedDollars * multiple);
    }
    
    public static Money operator -(Money money1, Money money2)
    {
        return new Money(money1._normalizedDollars - money2._normalizedDollars);
    }
    
    public static Money operator /(Money money, long divisor)
    {
        return new Money(money._normalizedDollars / divisor);
    }
}