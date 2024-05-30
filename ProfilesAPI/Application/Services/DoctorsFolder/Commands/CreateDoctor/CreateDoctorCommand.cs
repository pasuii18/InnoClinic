using Application.Common;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Services.DoctorsFolder.Commands.CreateDoctor;

public class CreateDoctorCommand : IRequest<ICustomResult>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public int CareerStartYear { get; set; }
    public DoctorStatus Status { get; set; }
    public Guid IdAccount { get; set; }
    public Guid IdSpecialization { get; set; }
    public Guid IdOffice { get; set; }
}