using Application.Interfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Commands.EditPatient;

public class EditPatientCommand : IRequest<ICustomResult>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Guid IdPhoto { get; set; }
}