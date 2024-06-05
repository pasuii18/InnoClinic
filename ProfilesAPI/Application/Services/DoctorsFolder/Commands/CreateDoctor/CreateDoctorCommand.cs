using Application.Interfaces;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Services.DoctorsFolder.Commands.CreateDoctor;

public class CreateDoctorCommand : IRequest<ICustomResult>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } // for account on AuthApi
    public int CareerStartYear { get; set; }
    public DoctorStatus Status { get; set; }
    public Guid IdAccount { get; set; }
    public Guid IdSpecialization { get; set; }
    public Guid IdOffice { get; set; }
    
    public static Doctor MapInDoctor(CreateDoctorCommand command)
    {
        return new Doctor
        {
            IdDoctor = Guid.NewGuid(),
            FirstName = command.FirstName,  
            LastName = command.LastName,  
            MiddleName = command.MiddleName,  
            DateOfBirth = command.DateOfBirth,
            CareerStartYear = command.CareerStartYear,
            Status = command.Status,
            IdAccount = command.IdAccount,
            IdSpecialization = command.IdSpecialization,
            IdOffice = command.IdOffice,
        };
    }
}