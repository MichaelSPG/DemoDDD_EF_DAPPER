namespace DemoDDD.Domain.Shared
{
    public record CurrencyKind
    {
        public static readonly CurrencyKind None = new("");
        public static readonly CurrencyKind Usd = new("USD");
        public static readonly CurrencyKind Eur = new("EUR");
        private CurrencyKind(string code) => Code = code;
        public string? Code { get; init; }

        public static readonly IReadOnlyCollection<CurrencyKind> All = new[]
        {
            Usd,
            Eur
        };

        public static CurrencyKind FromCode(string code)
        {
            return All.FirstOrDefault(x => x.Code == code) ?? throw new ApplicationException("Currency code is not valid");
        }
    }
}
