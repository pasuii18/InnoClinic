using Domain.Common.Enums;

namespace Application.Interfaces;

public interface IFiltersBase
{
    public OrderBy OrderBy { get; init; }
    public OrderType OrderType { get; init; }
}