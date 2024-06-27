using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces.RepoInterfaces;
using Dapper;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories;

public class AppointmentReadRepo(AppointmentsDbContext _context) : IAppointmentReadRepo
{
    public async Task<IReadOnlyCollection<Appointment>> GetAppointments(PageSettings pageSettings, 
        AppointmentsFilter filters, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.GetByFiltration(nameof(Appointment));

            if (filters.Date is not null)
                query.Append(CustomQueryBuilder.AddFilter(nameof(filters.Date)));
            if (filters.DoctorFullName is not null)
                query.Append(CustomQueryBuilder.AddFilter(nameof(filters.DoctorFullName)));
            if (filters.ServiceName is not null)
                query.Append(CustomQueryBuilder.AddFilter(nameof(filters.ServiceName)));
            if (filters.IdOffice is not null)
                query.Append(CustomQueryBuilder.AddFilter(nameof(filters.IdOffice)));
            if(filters.IsApproved != AppointmentStatus.All)
                query.Append(CustomQueryBuilder.AddApprovedFilter(filters.IsApproved));
            
            query.Append(CustomQueryBuilder.Order(OrderBy.StartTime, OrderType.Ascending));
            query.Append(CustomQueryBuilder.Pagination);

            var parameters = new DynamicParameters(filters);
            parameters.Add(nameof(pageSettings.Page), pageSettings.Page);
            parameters.Add(nameof(pageSettings.PageSize), pageSettings.PageSize);
            
            var appointments = await connection.QueryAsync<Appointment>(
                new CommandDefinition(
                    query.ToString(), parameters, cancellationToken: cancellationToken));

            return appointments.ToList().AsReadOnly();
        }
    }
    public async Task<IReadOnlyCollection<Appointment>> GetAppointmentsHistory(PageSettings pageSettings,
        CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.GetByFiltration(nameof(Appointment));
            query.Append(CustomQueryBuilder.Order(OrderBy.Date, OrderType.Descending));
            query.Append(CustomQueryBuilder.AddOrder(OrderBy.StartTime, OrderType.Ascending));
            query.Append(CustomQueryBuilder.Pagination);
            
            var parameters = new DynamicParameters(pageSettings);
            var appointments = await connection.QueryAsync<Appointment>(
                new CommandDefinition(
                    query.ToString(), parameters, cancellationToken: cancellationToken));

            return appointments.ToList().AsReadOnly();
        }
    }
    public async Task<IReadOnlyCollection<Appointment>> GetAppointmentsSchedule(Guid idDoctor, PageSettings pageSettings, 
        AppointmentsScheduleFilter filters, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.GetByFiltration(nameof(Appointment));
            
            if (idDoctor != Guid.Empty)
                query.Append(CustomQueryBuilder.AddFilter("IdDoctor"));

            query.Append(CustomQueryBuilder.AddFilter(nameof(filters.Date)));
            query.Append(CustomQueryBuilder.Order(OrderBy.StartTime, OrderType.Ascending));
            query.Append(CustomQueryBuilder.Pagination);
            
            var parameters = new DynamicParameters(filters);
            parameters.Add(nameof(pageSettings.Page), pageSettings.Page);
            parameters.Add(nameof(pageSettings.PageSize), pageSettings.PageSize);
            parameters.Add("IdDoctor", idDoctor);
            
            var appointments = await connection.QueryAsync<Appointment>(
                new CommandDefinition(
                    query.ToString(), parameters, cancellationToken: cancellationToken));

            return appointments.ToList().AsReadOnly();
        }
    }
    public async Task<Appointment?> GetAppointmentById(Guid idAppointment, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.GetById(nameof(Appointment));
            
            var appointment = await connection.QueryFirstOrDefaultAsync<Appointment>(
                new CommandDefinition(
                    query, new { IdAppointment = idAppointment }, cancellationToken: cancellationToken));

            return appointment;
        }
    }
    public async Task<Appointment?> GetAppointmentByFieldName<T>(T value, string fieldName, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.GetByFieldName(nameof(Appointment), fieldName);
            
            var parameters = new DynamicParameters();
            parameters.Add(fieldName, value);
            var appointment = await connection.QueryFirstOrDefaultAsync<Appointment>(
                new CommandDefinition(
                    query, parameters, cancellationToken: cancellationToken));

            return appointment;
        }
    }
}