using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface IDoctorsRepo
{
    public Task<IReadOnlyCollection<Doctor>> GetDoctors();
    public Task<Doctor> GetDoctorById(Guid idDoctor);
    public Task<Doctor> GetDoctorByFiltration(DoctorFilters filters);
    public Task CreateDoctor(Doctor doctor);
}