using System.Data;
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

public class AppointmentWriteRepo(AppointmentsDbContext _context) : IAppointmentWriteRepo
{
    public async Task CreateAppointment(Appointment appointment, CancellationToken cancellationToken)
    {
        await ExecuteInTransactionAsync(async (connection, transaction) =>
        {
            var query = "UPDATE \"Slot\" SET \"IsFree\" = false, \"IdAppointment\" = @IdAppointment " +
                        "WHERE \"Date\" = @Date AND \"StartTime\" >= @StartTime AND \"EndTime\" <= @EndTime";
            var parameters = CreateTimeParameters(appointment, true);
            await connection.ExecuteAsync(
                new CommandDefinition(query, parameters, transaction: transaction, cancellationToken: cancellationToken));

            var appointmentQuery = CustomQueryBuilder.Create(appointment);
            await connection.ExecuteAsync(
                new CommandDefinition(appointmentQuery, appointment, transaction: transaction, cancellationToken: cancellationToken));
        });
    }
    public async Task UpdateAppointmentAndSlot(Appointment oldAppointment, Appointment newAppointment,
        CancellationToken cancellationToken)
    {
        await ExecuteInTransactionAsync(async (connection, transaction) =>
        {
            var realiseQuery = "UPDATE \"Slot\" " +
                               "SET \"IsFree\" = true, \"IdAppointment\" = null " +
                               "WHERE \"Date\" = @OldDate AND \"StartTime\" >= @OldStartTime AND \"EndTime\" <= @OldEndTime";
            var realiseParameters = new DynamicParameters();
            realiseParameters.Add("OldDate", oldAppointment.Date);
            realiseParameters.Add("OldStartTime", new TimeSpan(oldAppointment.StartTime.Hour, oldAppointment.StartTime.Minute, oldAppointment.StartTime.Second));
            realiseParameters.Add("OldEndTime", new TimeSpan(oldAppointment.EndTime.Hour, oldAppointment.EndTime.Minute, oldAppointment.EndTime.Second));
            await connection.ExecuteAsync(
                new CommandDefinition(realiseQuery, realiseParameters, transaction: transaction, cancellationToken: cancellationToken));
            
            var reserveQuery = "UPDATE \"Slot\" " +
                               "SET \"IsFree\" = false, \"IdAppointment\" = @IdAppointment " +
                               "WHERE \"Date\" = @NewDate AND \"StartTime\" >= @NewStartTime AND \"EndTime\" <= @NewEndTime";
            var reserveParameters = new DynamicParameters();
            reserveParameters.Add("NewDate", newAppointment.Date);
            reserveParameters.Add("NewStartTime", new TimeSpan(newAppointment.StartTime.Hour, newAppointment.StartTime.Minute, newAppointment.StartTime.Second));
            reserveParameters.Add("NewEndTime", new TimeSpan(newAppointment.EndTime.Hour, newAppointment.EndTime.Minute, newAppointment.EndTime.Second));
            reserveParameters.Add("IdAppointment", oldAppointment.IdAppointment);
            await connection.ExecuteAsync(
                new CommandDefinition(reserveQuery, reserveParameters, transaction: transaction, cancellationToken: cancellationToken));

            var appointmentQuery = CustomQueryBuilder.UpdateById(newAppointment);
            await connection.ExecuteAsync(
                new CommandDefinition(appointmentQuery, newAppointment, transaction: transaction, cancellationToken: cancellationToken));
        });
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
    public async Task DeleteAppointment(Appointment appointment, CancellationToken cancellationToken)
    {
        await ExecuteInTransactionAsync(async (connection, transaction) =>
        {
            var query = "UPDATE \"Slot\" SET \"IsFree\" = true, \"IdAppointment\" = null " +
                        "WHERE \"Date\" = @Date AND \"StartTime\" >= @StartTime AND \"EndTime\" <= @EndTime";

            var parameters = CreateTimeParameters(appointment, true);

            await connection.ExecuteAsync(
                new CommandDefinition(query, parameters, transaction: transaction, cancellationToken: cancellationToken));

            var appointmentQuery = CustomQueryBuilder.DeleteById(nameof(Appointment));
            await connection.ExecuteAsync(
                new CommandDefinition(appointmentQuery, new { IdAppointment = appointment.IdAppointment }, 
                    transaction: transaction, cancellationToken: cancellationToken));
        });
    }
    
    private async Task ExecuteInTransactionAsync(Func<IDbConnection, IDbTransaction, Task> action)
    {
        using (var connection = _context.CreateConnection())
        {
            connection.Open();
            using (var transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                try
                {
                    await action(connection, transaction);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
    private DynamicParameters CreateTimeParameters(Appointment appointment, bool includeId = false)
    {
        var parameters = new DynamicParameters();
        if (includeId) parameters.Add("IdAppointment", appointment.IdAppointment);
        parameters.Add("Date", appointment.Date);
        parameters.Add("StartTime", new TimeSpan(appointment.StartTime.Hour, appointment.StartTime.Minute, appointment.StartTime.Second));
        parameters.Add("EndTime", new TimeSpan(appointment.EndTime.Hour, appointment.EndTime.Minute, appointment.EndTime.Second));
        return parameters;
    }
}