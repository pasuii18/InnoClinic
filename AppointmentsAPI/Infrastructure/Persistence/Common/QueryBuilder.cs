using System.Text;
using Domain.Common;

namespace Infrastructure.Persistence.Common;

public static class QueryBuilder
{
    public static string Pagination => 
        " LIMIT @PageSize OFFSET (@Page - 1) * @PageSize";

    public static StringBuilder GetByFiltration(string tableName) => 
        new StringBuilder($"SELECT * FROM \"{tableName}\" WHERE 1=1");

    public static string AddFilter(string field) => 
        $" AND \"{field}\" = @{field}";
    public static string AddApprovedFilter(AppointmentStatus status) => 
        $" AND \"IsApproved\" = {(status == AppointmentStatus.Approved ? "true" : "false")}";

    public static string Order(OrderBy field, OrderType type) => 
        $" ORDER BY \"{field}\" {(type == OrderType.Ascending ? "ASC" : "DESC")}";

    public static string AddOrder(OrderBy field, OrderType type) => 
        $", \"{field}\" {(type == OrderType.Ascending ? "ASC" : "DESC")}";

    public static string GetById(string tableName) => 
        $"SELECT * FROM \"{tableName}\" WHERE \"Id{tableName}\" = @Id{tableName}";

    public static string GetByOtherId(string tableName, string columnName) => 
        $"SELECT * FROM \"{tableName}\" WHERE \"Id{columnName}\" = @Id{columnName}";

    public static string DeleteById(string tableName) => 
        $"DELETE FROM \"{tableName}\" WHERE \"Id{tableName}\" = @Id{tableName}";

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
}