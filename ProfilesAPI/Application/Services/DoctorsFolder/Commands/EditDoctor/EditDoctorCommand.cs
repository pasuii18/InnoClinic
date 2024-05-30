using Application.Common;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Services.DoctorsFolder.Commands.EditDoctor;

public class EditDoctorCommand : IRequest<ICustomResult>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int CareerStartYear { get; set; }
    public DoctorStatus Status { get; set; }
    public Guid IdPhoto { get; set; }
    public Guid IdSpecialization { get; set; }
    public Guid IdOffice { get; set; }
}