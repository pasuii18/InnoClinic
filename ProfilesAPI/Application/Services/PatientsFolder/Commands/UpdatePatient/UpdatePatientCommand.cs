using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Services.PatientsFolder.Commands.UpdatePatient;

public class UpdatePatientCommand : IRequest<ICustomResult>
{
    public Guid IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Guid IdPhoto { get; set; }
    
    public void MapInPatient(Patient patient)
    {
        patient.FirstName = FirstName;
        patient.LastName = LastName;
        patient.MiddleName = MiddleName;
        patient.DateOfBirth = DateOfBirth;
        
        // need to work with AuthAPI somehow >:(
        // patient.PhoneNumber = request.PhoneNumber;
        // patient.IdPhoto = request.IdPhoto;
    }
}