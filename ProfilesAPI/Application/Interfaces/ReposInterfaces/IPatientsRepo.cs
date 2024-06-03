using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface IPatientsRepo
{
    public Task<IReadOnlyCollection<Patient>> GetPatients(
        PatientFilters filters, PageSettings pageSettings, CancellationToken cancellationToken);
    public Task<Patient> GetPatientById(
        Guid idPatient, CancellationToken cancellationToken);
    public Task CreatePatient(
        Patient patient, CancellationToken cancellationToken);
    public Task UpdatePatient(
        Patient patient, CancellationToken cancellationToken);
    public Task DeletePatient(
        Guid idPatient, CancellationToken cancellationToken);
}