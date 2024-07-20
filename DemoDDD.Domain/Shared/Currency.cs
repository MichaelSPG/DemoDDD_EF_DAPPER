namespace DemoDDD.Domain.Shared
{
    public record Currency(decimal Value, CurrencyKind CurrencyKind)
    {
        public static Currency operator +(Currency left, Currency right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }
            if (left.CurrencyKind != right.CurrencyKind)
            {
                throw new InvalidOperationException("Both currency kind are not equals");
            }
            return new Currency(left.Value + right.Value, left.CurrencyKind);
        }
        public static Currency Zero() => new Currency(0, CurrencyKind.None);
        public static Currency Zero(CurrencyKind currencyKind) => new Currency(0, currencyKind);
        public bool IsZero() => this == Zero(CurrencyKind);
    }
}
