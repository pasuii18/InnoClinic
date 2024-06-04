using Application.Common;
using Application.Interfaces;
using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Services.DoctorsFolder.Commands.EditDoctor;

public class UpdateDoctorCommand : IRequest<ICustomResult>
{
    public Guid IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int CareerStartYear { get; set; }
    public DoctorStatus Status { get; set; }
    public Guid IdPhoto { get; set; } // authAPI
    public Guid IdSpecialization { get; set; }
    public Guid IdOffice { get; set; }
    
    public void MapInDoctor(Doctor doctor)
    {
        doctor.FirstName = FirstName;
        doctor.LastName = LastName;
        doctor.MiddleName = MiddleName;
        doctor.DateOfBirth = DateOfBirth;
        doctor.CareerStartYear = CareerStartYear;
        doctor.Status = Status;
        doctor.IdSpecialization = IdSpecialization;
        doctor.IdOffice = IdOffice;
        
    }
}