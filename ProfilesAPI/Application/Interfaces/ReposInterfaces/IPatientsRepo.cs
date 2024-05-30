using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface IPatientsRepo
{
    public Task<IReadOnlyCollection<Patient>> GetPatients();
    public Task<IReadOnlyCollection<Patient>> GetPatientsByFiltration(PatientFilters filters);
    public Task<Patient> GetPatientById(Guid idPatient);
    public Task CreatePatient(Patient patient);
    public Task DeletePatient(Guid idPatient);
}