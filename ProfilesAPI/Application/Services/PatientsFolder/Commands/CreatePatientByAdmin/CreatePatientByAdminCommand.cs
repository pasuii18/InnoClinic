using Application.Interfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Commands.CreatePatientByAdmin;

public class CreatePatientByAdminCommand : IRequest<ICustomResult>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public bool IsLinkedToAccount { get; set; } = false;
    public DateTime DateOfBirth { get; set; }
    public Guid IdPhoto { get; set; }
}