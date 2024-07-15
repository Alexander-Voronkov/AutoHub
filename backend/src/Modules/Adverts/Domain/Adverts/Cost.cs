using AutoHub.BuildingBlocks.Domain;

namespace AutoHub.Modules.Adverts.Domain.Adverts;

public class Cost : ValueObject
{
    public string _currencyCode { get; }

    public decimal _cost { get; }

    public static Cost CreateCost(
        string currencyCode,
        decimal cost)
    {
        return new Cost(currencyCode, cost);
    }

    private Cost()
    {
        // ef
    }

    private Cost(
        string currencyCode,
        decimal cost)
    {
        _currencyCode = currencyCode;
        _cost = cost;
    }
}