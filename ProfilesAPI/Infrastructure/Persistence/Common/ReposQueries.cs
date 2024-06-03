using System.Text;

namespace Infrastructure.Persistence.Common;

public static class ReposQueries
{
    public static string Pagination => 
        " OFFSET (@Page - 1) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY";
    public static string GetAllFrom(string tableName) => 
        $"SELECT * FROM {tableName}";
    public static StringBuilder GetByFiltration(string tableName) => 
        new StringBuilder($"SELECT * FROM {tableName} WHERE 1=1");
    public static string AddFilter(string field) => 
        $" AND {field} = @{field}";
    public static string AddFullNameFilter(string[] fields)
    {
        var stringBuilder = new StringBuilder();
        foreach (var field in fields)
        {
            stringBuilder.Append($" AND (FirstName LIKE '%{field}%' OR LastName LIKE '%{field}%' OR MiddleName LIKE '%{field}%')");
        }

        return stringBuilder.ToString();
    }
    public static string AddOrder(string field, bool type) => 
        $" ORDER BY {field} {(type ? "ASC" : "DESC")}";
    public static string GetById(string tableName) => 
        $"SELECT * FROM {tableName} WHERE Id{tableName} = @Id{tableName}";
    public static string DeleteById(string tableName) => 
        $"DELETE FROM {tableName} WHERE Id{tableName} = @Id{tableName}";
    
    public static string Create<T>(T entity)
    {
        var tableName = typeof(T).Name;
        var properties = typeof(T).GetProperties()
            .Where(prop => prop.GetValue(entity) != null)
            .Select(prop => $"{prop.Name}");

        string createFields = string.Join(", ", properties);
        string createValues = string.Join(", @", properties);

        return $"INSERT INTO {tableName} ({createFields}) VALUES (@{createValues})";
    }
    
    public static string UpdateById<T>(T entity)
    {
        var tableName = typeof(T).Name;
        var properties = typeof(T).GetProperties()
            .Where(prop => prop.Name != $"Id{tableName}" && prop.GetValue(entity) != null)
            .Select(prop => $"{prop.Name} = @{prop.Name}");

        string updateFields = string.Join(", ", properties);

        return $"UPDATE {tableName} SET {updateFields} WHERE Id{tableName} = @Id{tableName}";
    }
}