using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface IDoctorsRepo
{
    public Task<IReadOnlyCollection<Doctor>> GetDoctors(
        PageSettings pageSettings, CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<Doctor>> GetDoctorsByFiltration(
        PageSettings pageSettings, DoctorFilters filters, CancellationToken cancellationToken);
    public Task<Doctor> GetDoctorById(
        Guid idDoctor, CancellationToken cancellationToken);
    public Task CreateDoctor(
        Doctor doctor, CancellationToken cancellationToken);
}