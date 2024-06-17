using Domain.Common;

namespace Application.Interfaces;

public interface IFilterBase
{
    OrderBy OrderBy { get; init; }
    OrderType OrderType { get; init; }
}