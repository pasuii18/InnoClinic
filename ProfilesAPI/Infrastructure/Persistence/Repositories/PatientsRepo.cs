using System.Text;
using Application.Common.Dtos.Filters;
using Application.Interfaces.ReposInterfaces;
using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories;

public class PatientsRepo(ProfilesDbContext _context) : IPatientsRepo
{
    public async Task<IReadOnlyCollection<Patient>> GetPatients()
    {
        using (var connection = _context.CreateConnection())
        {
            var query = "SELECT * FROM Patient";
            var patients = await connection.QueryAsync<Patient>(query);
            return patients.ToList().AsReadOnly();
        }
    }

    public async Task<Patient> GetPatientById(Guid idPatient)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = "SELECT * FROM Patient WHERE IdPatient = @idPatient";
            var patient = await connection.QuerySingleOrDefaultAsync<Patient>(query, new { idPatient });
            return patient;
        }
    }

    public async Task<IReadOnlyCollection<Patient>> GetPatientsByFiltration(PatientFilters filters)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = new StringBuilder("SELECT * FROM Patient WHERE 1=1");

            // if (!string.IsNullOrEmpty(filters.FullName)) query.Append(" AND FirstName LIKE @FullName");

            var patients = await connection.QueryAsync<Patient>(query.ToString(), filters);
            return patients.ToList().AsReadOnly();
        }
    }

    // fix
    public async Task CreatePatient(Patient patient)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = @"INSERT INTO Patient (IdPatient, FirstName, LastName, MiddleName, IsLinkedToAccount, DateOfBirth, IdAccount)
                            VALUES (@IdPatient, @FirstName, @LastName, @MiddleName, @IsLinkedToAccount, @DateOfBirth, @IdAccount)";

            patient.IdPatient = Guid.NewGuid();

            await connection.ExecuteAsync(query, patient);
        }
    }

    public async Task DeletePatient(Guid idPatient)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = "DELETE FROM Patient WHERE IdPatient = @idPatient";
            await connection.ExecuteAsync(query, new { idPatient });
        }
    }
}