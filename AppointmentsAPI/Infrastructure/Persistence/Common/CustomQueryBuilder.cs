using System.Text;
using Domain.Common;

namespace Infrastructure.Persistence.Common;

public static class CustomQueryBuilder
{
    public static string Pagination => 
        " LIMIT @PageSize OFFSET (@Page - 1) * @PageSize";
    public static string Filtration => 
        " WHERE 1=1";
    
    public static StringBuilder GetBy(string tableName) => 
        new StringBuilder($"SELECT * FROM \"{tableName}\"");

    public static StringBuilder GetByFiltration(string tableName) => 
        new StringBuilder($"SELECT * FROM \"{tableName}\" WHERE 1=1");

    public static string AddFilter(string field) => 
        $" AND \"{field}\" = @{field}";
    public static string AddJoinFilter(string tableName, string field) => 
        $" AND \"{tableName}\".\"{field}\" = @{field}";
    public static string AddApprovedFilter(AppointmentStatus status) => 
        $" AND \"IsApproved\" = {(status == AppointmentStatus.Approved ? "true" : "false")}";
    public static string AddTimeBordersFilter(string startTime, string endTime) => 
        $" AND \"StartTime\" >= @{startTime} AND \"EndTime\" <= @{endTime}";

    public static string Order(OrderBy field, OrderType type) => 
        $" ORDER BY \"{field}\" {(type == OrderType.Ascending ? "ASC" : "DESC")}";
    public static string AddOrder(OrderBy field, OrderType type) => 
        $", \"{field}\" {(type == OrderType.Ascending ? "ASC" : "DESC")}";

    public static string GetById(string tableName) => 
        $"SELECT * FROM \"{tableName}\" WHERE \"Id{tableName}\" = @Id{tableName}";
    public static string GetByFieldName(string tableName, string fieldName) => 
        $"SELECT * FROM \"{tableName}\" WHERE \"{fieldName}\" = @{fieldName}";

    public static string DeleteById(string tableName) => 
        $"DELETE FROM \"{tableName}\" WHERE \"Id{tableName}\" = @Id{tableName}";
    
    public static string LeftJoin(string leftTable, string rightTable, string field) => 
        $" LEFT JOIN \"{rightTable}\" ON \"{leftTable}\".\"{field}\" = \"{rightTable}\".\"{field}\"";

    public static string Create<T>(T entity)
    {
        var tableName = typeof(T).Name;
        var properties = typeof(T).GetProperties()
            .Where(prop => prop.GetValue(entity) != null)
            .Select(prop => $"\"{prop.Name}\"");

        string createFields = string.Join(", ", properties);
        string createValues = string.Join(", @", properties.Select(p => p.Trim('\"')));

        return $"INSERT INTO \"{tableName}\" ({createFields}) VALUES (@{createValues})";
    }

    public static string UpdateById<T>(T entity)
    {
        var tableName = typeof(T).Name;
        var properties = typeof(T).GetProperties()
            .Where(prop => prop.Name != $"Id{tableName}" && prop.GetValue(entity) != null)
            .Select(prop => $"\"{prop.Name}\" = @{prop.Name}");

        string updateFields = string.Join(", ", properties);

        return $"UPDATE \"{tableName}\" SET {updateFields} WHERE \"Id{tableName}\" = @Id{tableName}";
    }
    public static StringBuilder UpdateField(string tableName, string fieldName)
    {
        return new StringBuilder($"UPDATE \"{tableName}\" SET \"{fieldName}\" = @{fieldName}");
    }
}