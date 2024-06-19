using System.Data;
using Dapper;

namespace Infrastructure.Persistence.Common.MappingHandlers;

public class TimeOnlyTypeHandler : SqlMapper.TypeHandler<TimeOnly>
{
    public override void SetValue(IDbDataParameter parameter, TimeOnly value)
    {
        parameter.Value = DateTime.MinValue.Add(value.ToTimeSpan());
    }

    public override TimeOnly Parse(object value)
    {
        if (value is TimeSpan timeSpan)
        {
            return TimeOnly.FromTimeSpan(timeSpan);
        }

        throw new InvalidCastException($"Unable to cast object of type '{value.GetType()}' to type 'System.TimeSpan'.");
    }
}