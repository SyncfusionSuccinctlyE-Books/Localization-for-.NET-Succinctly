using System;
using System.Globalization;

namespace Money
{
public struct Money : IEquatable<Money>, IComparable, IComparable<Money>, ICloneable
{
    private readonly decimal _amount;
    private readonly CultureInfo _cultureInfo;
    private readonly RegionInfo _regionInfo;

    public Money(decimal amount, string cultureName) : this(amount, new CultureInfo(cultureName))
    {
    }

    public Money(decimal amount, CultureInfo cultureInfo)
    {
        if (cultureInfo == null) throw new ArgumentNullException("cultureInfo");
        _cultureInfo = cultureInfo;
        _regionInfo = new RegionInfo(cultureInfo.LCID);
        _amount = amount;
    }

    public string ISOCurrencySymbol
    {
        get { return _regionInfo.ISOCurrencySymbol; }
    }

    public decimal Amount
    {
        get { return _amount; }
    }

    public int DecimalDigits
    {
        get { return _cultureInfo.NumberFormat.CurrencyDecimalDigits; }
    }

    object ICloneable.Clone()
    {
        return new Money(_amount, _cultureInfo);
    }

    public int CompareTo(object obj)
    {
        if (obj == null) throw new ArgumentNullException("obj");
        if (!(obj is Money))
            throw new ArgumentException(string.Format("Argument must be of type Money, got '{0}'.", obj));

        var other = (Money)obj;
        return CompareTo(other);
    }

    public int CompareTo(Money other)
    {
        if (this < other)
            return -1;
        return this > other ? 1 : 0;
    }

    public bool Equals(Money other)
    {
        if (ReferenceEquals(other, null)) return false;
        return ((ISOCurrencySymbol == other.ISOCurrencySymbol) && (_amount == other._amount));
    }

    public static bool operator >(Money first, Money second)
    {
        AssertSameCurrency(first, second);
        return first._amount > second._amount;
    }

    public static bool operator >=(Money first, Money second)
    {
        AssertSameCurrency(first, second);
        return first._amount >= second._amount;
    }

    public static bool operator <=(Money first, Money second)
    {
        AssertSameCurrency(first, second);
        return first._amount <= second._amount;
    }

    public static bool operator <(Money first, Money second)
    {
        AssertSameCurrency(first, second);
        return first._amount < second._amount;
    }

    public static Money operator +(Money first, Money second)
    {
        AssertSameCurrency(first, second);
        return new Money(first.Amount + second.Amount, first._cultureInfo);
    }
    public static Money operator +(Money first, decimal second)
    {
        return new Money(first.Amount + second, first._cultureInfo);
    }

    public static Money Add(Money first, Money second)
    {
        return first + second;
    }

    public static Money operator -(Money first, Money second)
    {
        AssertSameCurrency(first, second);
        return new Money(first.Amount - second.Amount, first._cultureInfo);
    }

    public static Money Subtract(Money first, Money second)
    {
        return first - second;
    }

    /// <summary>
    ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
    /// </summary>
    /// <param name="obj">
    ///     The <see cref="System.Object" /> to compare with this instance.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals(object obj)
    {
        return (obj is Money) && Equals((Money) obj);
    }

    /// <summary>
    ///     Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    public override int GetHashCode()
    {
        return _amount.GetHashCode() ^ _cultureInfo.GetHashCode();
    }

    /// <summary>
    /// Asserts the same currency.
    /// </summary>
    /// <param name="first">The first.</param>
    /// <param name="second">The second.</param>
    /// <exception cref="System.FormatException"></exception>
    private static void AssertSameCurrency(Money first, Money second)
    {
        if (first == null) throw new ArgumentNullException("first");
        if (second == null) throw new ArgumentNullException("second");
        if (first.ISOCurrencySymbol != second.ISOCurrencySymbol)
            throw new FormatException(string.Format("Currency: {0}, other currency: {1}", first.ISOCurrencySymbol,
                                                    second.ISOCurrencySymbol));
    }

    public static bool operator ==(Money first, Money second)
    {
        if (ReferenceEquals(first, second)) return true;
        if (ReferenceEquals(first, null) || ReferenceEquals(second, null)) return false;
        return Equals(first, second);
    }

    public static bool operator !=(Money first, Money second)
    {
        if (first == null) throw new ArgumentNullException("first");
        if (second == null) throw new ArgumentNullException("second");
        return !first.Equals(second);
    }

    public static Money operator *(Money money, decimal value)
    {
        if (money == null) throw new ArgumentNullException("money");

        return new Money(money.Amount*value, money._cultureInfo);
    }

    public static Money Multiply(Money money, decimal value)
    {
        if (money == null) throw new ArgumentNullException("money");
        return money*value;
    }

    public static Money operator /(Money money, decimal value)
    {
        if (money == null) throw new ArgumentNullException("money");

        return new Money(money.Amount/value, money._cultureInfo);
    }

    public static Money Divide(Money first, decimal value)
    {
        if (first == null) throw new ArgumentNullException("first");
        return first/value;
    }

    public Money Clone()
    {
        return new Money(_amount, _cultureInfo);
    }

    public override string ToString()
    {
        return Amount.ToString("C", _cultureInfo);
    }


    public string ToString(string format)
    {
        return Amount.ToString(format, _cultureInfo);
    }
}
}