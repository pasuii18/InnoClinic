using System.Text;
using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces.ReposInterfaces;
using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories;

public class DoctorsRepo(ProfilesDbContext _context)
    : IDoctorsRepo
{
    private const string TableName = "Doctor";
    
    public async Task<IReadOnlyCollection<Doctor>> GetDoctors(
        PageSettings pageSettings, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = ReposQueries.GetAllFrom(TableName) + ReposQueries.Pagination;
            var doctors = await connection.QueryAsync<Doctor>(query, pageSettings);
            return doctors.ToList().AsReadOnly();
        }
    }
    
    public async Task<IReadOnlyCollection<Doctor>> GetDoctorsByFiltration(
        PageSettings pageSettings, DoctorFilters filters, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = ReposQueries.GetByFiltration(TableName);
            
            if (!string.IsNullOrEmpty(filters.FullName)) 
                query.Append(ReposQueries.AddFilter(nameof(filters.FullName)));
            if (filters.IdSpecialization != Guid.Empty) 
                query.Append(ReposQueries.AddFilter(nameof(filters.IdSpecialization)));
            if (filters.IdOffice != Guid.Empty) 
                query.Append(ReposQueries.AddFilter(nameof(filters.IdOffice)));
            
            query.Append(ReposQueries.Pagination);
            var parameters = new DynamicParameters(filters);
            parameters.Add("Page", pageSettings.Page);
            parameters.Add("PageSize", pageSettings.PageSize);
            var doctors = await connection.QueryAsync<Doctor>(query.ToString(), parameters);
            return doctors.ToList().AsReadOnly();
        }
    }

    public async Task<Doctor> GetDoctorById(
        Guid idDoctor, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = ReposQueries.GetById(TableName);
            var doctor = await connection.QueryFirstOrDefaultAsync(query, new { idDoctor });
            return doctor;
        }
    }

    public async Task CreateDoctor(
        Doctor doctor, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = @"INSERT INTO Doctors 
                (IdDoctor, FirstName, LastName, MiddleName, 
                 DateOfBirth, CareerStartYear, Status, IdAccount, 
                 IdSpecialization, IdOffice)
                        VALUES 
                (@IdDoctor, @FirstName, @LastName, @MiddleName, 
                 @DateOfBirth, @CareerStartYear, @Status, @IdAccount, 
                 @IdSpecialization, @IdOffice)";
    
            await connection.ExecuteAsync(query, doctor);
        }
    }
}