using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces.ReposInterfaces;
using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories;

public class PatientsRepo(ProfilesDbContext _context) 
    : IPatientsRepo
{
    public async Task<IReadOnlyCollection<Patient>> GetPatients(
        PatientFilters filters, PageSettings pageSettings, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.GetByFiltration(nameof(Patient));
            
            if (!string.IsNullOrEmpty(filters.FullName)) 
                query.Append(CustomQueryBuilder.AddFullNameFilter(filters.FullName));

            query.Append(CustomQueryBuilder.AddOrder(filters.OrderBy, filters.OrderType));
            query.Append(CustomQueryBuilder.Pagination);
            
            var parameters = new DynamicParameters(filters);
            parameters.Add(nameof(pageSettings.Page), pageSettings.Page);
            parameters.Add(nameof(pageSettings.PageSize), pageSettings.PageSize);
            var patients = await connection.QueryAsync<Patient>(
                new CommandDefinition(query.ToString(), parameters, cancellationToken: cancellationToken));
            return patients.ToList().AsReadOnly();
        }
    }
    
    public async Task<Patient> GetPatientById(
        Guid idPatient, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.GetById(nameof(Patient));
            var patient = await connection.QuerySingleOrDefaultAsync<Patient>(
                new CommandDefinition(query, new { idPatient }, cancellationToken: cancellationToken));
            return patient;
        }
    }

    public async Task CreatePatient(
        Patient patient, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.Create(patient);
            await connection.ExecuteAsync(
                new CommandDefinition(query, patient, cancellationToken: cancellationToken));
        }
    }

    public async Task UpdatePatient(
        Patient patient, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.UpdateById(patient);
            await connection.ExecuteAsync(
                new CommandDefinition(query, patient, cancellationToken: cancellationToken));
        }
    }

    public async Task DeletePatient(
        Guid idPatient, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.DeleteById(nameof(Patient));
            await connection.ExecuteAsync(
                new CommandDefinition(query, new { idPatient }, cancellationToken: cancellationToken));
        }
    }
}