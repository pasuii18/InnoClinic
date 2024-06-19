using Application.Common.Dtos;
using Application.Common.Dtos.AppointmentsDtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces.RepoInterfaces;
using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories;

public class AppointmentRepo(AppointmentsDbContext _context) : IAppointmentRepo
{
    public async Task<IReadOnlyCollection<Appointment>> GetAppointments(PageSettings pageSettings, 
        AppointmentsFilter filters, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = QueryBuilder.GetByFiltration(nameof(Appointment));

            if (filters.Date is not null)
                query.Append(QueryBuilder.AddFilter(nameof(filters.Date)));
                
            query.Append(QueryBuilder.AddFilter(nameof(filters.AppointmentStatus)));
            query.Append(QueryBuilder.Order(filters.OrderBy, filters.OrderType));
            // query.Append(QueryBuilder.AddOrder(filters.OrderBy, filters.OrderType));
            query.Append(QueryBuilder.Pagination);

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
        AppointmentsFilter filters, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = QueryBuilder.GetByFiltration(nameof(Appointment));
            
            if (filters.Date is not null)
                query.Append(QueryBuilder.AddFilter(nameof(filters.Date)));
            

            query.Append(QueryBuilder.AddFilter(nameof(filters.Date)));
            query.Append(QueryBuilder.Order(filters.OrderBy, filters.OrderType));
            query.Append(QueryBuilder.Pagination);
            
            var parameters = new DynamicParameters(filters);
            parameters.Add(nameof(pageSettings.Page), pageSettings.Page);
            parameters.Add(nameof(pageSettings.PageSize), pageSettings.PageSize);
            var appointments = await connection.QueryAsync<Appointment>(
                new CommandDefinition(
                    query.ToString(), parameters, cancellationToken: cancellationToken));

            return appointments.ToList().AsReadOnly();
        }
    }

    public async Task<IReadOnlyCollection<Appointment>> GetAppointmentsSchedule(PageSettings pageSettings, 
        AppointmentsFilter filters, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = QueryBuilder.GetByFiltration(nameof(Appointment));
            
            if (filters.Date is not null)
                query.Append(QueryBuilder.AddFilter(nameof(filters.Date)));
            

            query.Append(QueryBuilder.AddFilter(nameof(filters.Date)));
            query.Append(QueryBuilder.Order(filters.OrderBy, filters.OrderType));
            query.Append(QueryBuilder.Pagination);
            
            var parameters = new DynamicParameters(filters);
            parameters.Add(nameof(pageSettings.Page), pageSettings.Page);
            parameters.Add(nameof(pageSettings.PageSize), pageSettings.PageSize);
            var appointments = await connection.QueryAsync<Appointment>(
                new CommandDefinition(
                    query.ToString(), parameters, cancellationToken: cancellationToken));

            return appointments.ToList().AsReadOnly();
        }
    }

    public async Task<Appointment?> GetAppointmentsById(Guid idAppointment, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = QueryBuilder.GetById(nameof(Appointment));
            
            var appointment = await connection.QueryFirstOrDefaultAsync<Appointment>(
                new CommandDefinition(
                    query.ToString(), new { IdAppointment = idAppointment }, cancellationToken: cancellationToken));

            return appointment;
        }
    }

    public async Task CreateAppointment(Appointment appointment, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = QueryBuilder.Create(appointment);
            await connection.ExecuteAsync(
                new CommandDefinition(
                    query, appointment, cancellationToken: cancellationToken));
        }
    }

    public async Task UpdateAppointment(Appointment appointment, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = QueryBuilder.UpdateById(appointment);
            await connection.ExecuteAsync(
                new CommandDefinition(
                    query, appointment, cancellationToken: cancellationToken));
        }
    }

    public async Task UpdateAppointmentStatus(Appointment appointment, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = QueryBuilder.UpdateById(appointment);
            await connection.ExecuteAsync(
                new CommandDefinition(
                    query, appointment, cancellationToken: cancellationToken));
        }
    }

    public async Task DeleteAppointment(Guid idAppointment, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = QueryBuilder.DeleteById(nameof(Appointment));
            await connection.ExecuteAsync(
                new CommandDefinition(
                    query, new { IdAppointment = idAppointment }, cancellationToken: cancellationToken));
        }
    }
}