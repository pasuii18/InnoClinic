using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Services.PatientsFolder.Commands.CreatePatient;

public class CreatePatientCommand : IRequest<ICustomResult>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string PhoneNumber { get; set; } // only for patient || ex for admin
    public bool IsLinkedToAccount { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Guid IdPhoto { get; set; } // for AuthAPI 

    public static Patient MapInPatient(CreatePatientCommand command)
    {
        return new Patient
        {
            IdPatient = Guid.NewGuid(),
            FirstName = command.FirstName,  
            LastName = command.LastName,  
            MiddleName = command.MiddleName,  
            IsLinkedToAccount = command.IsLinkedToAccount,  
            DateOfBirth = command.DateOfBirth
        };
    }
}