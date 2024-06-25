using Application.Common.Dtos;
using Application.Common.Dtos.AppointmentsDtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces.RepoInterfaces;
using Dapper;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.Extensions.Primitives;

namespace Infrastructure.Persistence.Repositories;

public class AppointmentRepo(AppointmentsDbContext _context) : IAppointmentRepo
{
    public async Task<IReadOnlyCollection<Appointment>> GetAppointments(PageSettings pageSettings, 
        AppointmentsFilter filters, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.GetByFiltration(nameof(Appointment));

            if (filters.Date is not null)
                query.Append(CustomQueryBuilder.AddFilter(nameof(filters.Date)));
            if(filters.IsApproved != AppointmentStatus.All)
                query.Append(CustomQueryBuilder.AddApprovedFilter(filters.IsApproved));
            
            query.Append(CustomQueryBuilder.Order(OrderBy.Time, OrderType.Ascending));
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
            query.Append(CustomQueryBuilder.AddOrder(OrderBy.Time, OrderType.Ascending));
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
            query.Append(CustomQueryBuilder.Order(OrderBy.Time, OrderType.Ascending));
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
    public async Task CreateAppointment(Appointment appointment, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.Create(appointment);
            await connection.ExecuteAsync(
                new CommandDefinition(
                    query, appointment, cancellationToken: cancellationToken));
        }
    }
    public async Task UpdateAppointment(Appointment appointment, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.UpdateById(appointment);
            await connection.ExecuteAsync(
                new CommandDefinition(
                    query, appointment, cancellationToken: cancellationToken));
        }
    }
    public async Task UpdateAppointmentField<T, T2>(T fieldValue, string fieldName, 
        T2 conditionFieldValue, string conditionFieldName, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.UpdateField(nameof(Appointment), fieldName);
            query.Append(CustomQueryBuilder.Filtration);
            query.Append(CustomQueryBuilder.AddFilter(conditionFieldName));
            
            var parameters = new DynamicParameters();
            parameters.Add(fieldName, fieldValue);
            parameters.Add(conditionFieldName, conditionFieldValue);
            await connection.ExecuteAsync(
                new CommandDefinition(
                    query.ToString(), parameters, cancellationToken: cancellationToken));
        }
    }
    public async Task DeleteAppointment(Guid idAppointment, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.DeleteById(nameof(Appointment));
            await connection.ExecuteAsync(
                new CommandDefinition(
                    query, new { IdAppointment = idAppointment }, cancellationToken: cancellationToken));
        }
    }
}