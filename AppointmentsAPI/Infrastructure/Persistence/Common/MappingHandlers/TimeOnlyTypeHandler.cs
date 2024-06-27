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
        return TimeOnly.FromTimeSpan((TimeSpan)value);
    }
}