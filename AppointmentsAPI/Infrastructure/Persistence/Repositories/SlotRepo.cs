using Application.Interfaces.RepoInterfaces;
using Dapper;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Http.Extensions;

namespace Infrastructure.Persistence.Repositories;

public class SlotRepo(AppointmentsDbContext _context) : ISlotRepo
{
    public async Task<List<DateOnly>> GetDates(CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = "SELECT DISTINCT \"Date\" FROM \"Slot\"";
            var slots = await connection.QueryAsync<DateOnly>(
                new CommandDefinition(query, cancellationToken: cancellationToken));
            return slots.ToList();
        }
    }
    public async Task<List<DateOnly>> GetAvailableDates(CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = "SELECT DISTINCT \"Date\" FROM \"Slot\" " +
                        "WHERE \"IsFree\" = true " +
                        "ORDER BY \"Date\" ASC";
            var slots = await connection.QueryAsync<DateOnly>(
                new CommandDefinition(query, cancellationToken: cancellationToken));
            return slots.ToList();
        }
    }
    public async Task<List<Slot>> GetAvailableSlotsOnDate(DateOnly date, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.GetByFiltration(nameof(Slot));
            query.Append(CustomQueryBuilder.AddFilter("Date"));
            query.Append(CustomQueryBuilder.AddFilter("IsFree"));
            query.Append(CustomQueryBuilder.Order(OrderBy.Date, OrderType.Ascending));
            query.Append(CustomQueryBuilder.AddOrder(OrderBy.StartTime, OrderType.Ascending));
            
            var parameters = new DynamicParameters();
            parameters.Add("Date", date);
            parameters.Add("IsFree", true);
            var slots = await connection.QueryAsync<Slot>(
                    new CommandDefinition(query.ToString(), parameters, cancellationToken: cancellationToken));
            return slots.ToList();
        }
    }
    public async Task<IReadOnlyCollection<Slot>> GetSlotsByDateAndTime(DateOnly date, TimeOnly startTime, 
        TimeOnly endTime, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.GetByFiltration(nameof(Slot));
            query.Append(CustomQueryBuilder.AddFilter("Date"));
            query.Append(CustomQueryBuilder.AddTimeBordersFilter("StartTime", "EndTime"));
            query.Append(CustomQueryBuilder.Order(OrderBy.Date, OrderType.Ascending));
            query.Append(CustomQueryBuilder.AddOrder(OrderBy.StartTime, OrderType.Ascending));

            var parameters = new DynamicParameters();
            parameters.Add("Date", date);
            parameters.Add("StartTime", new TimeSpan(startTime.Hour, startTime.Minute, startTime.Second));
            parameters.Add("EndTime", new TimeSpan(endTime.Hour, endTime.Minute, endTime.Second));
            var slots = await connection.QueryAsync<Slot>(
                new CommandDefinition(query.ToString(), parameters, cancellationToken: cancellationToken));
            return slots.ToList().AsReadOnly();
        }
    }
    public async Task ScheduleSlots(List<Slot> slots, List<DateOnly> dates, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var deleteQuery = "DELETE FROM \"Slot\" WHERE \"Date\" = ANY(@Dates)";
            await connection.ExecuteAsync(
                new CommandDefinition(deleteQuery, new { Dates = dates }, cancellationToken: cancellationToken));


            // var query = "INSERT INTO \"Slots\" " +
            //             "(\"IdSlot\", \"Date\", \"StartTime\", \"EndTime\", \"IsFree\") " +
            //             "VALUES " +
            //             "(@IdSlot, @Date, @StartTime, @EndTime, true)";
            var query = CustomQueryBuilder.Create(slots.First());
            foreach (var slot in slots)
            {
                await connection.ExecuteAsync(
                    new CommandDefinition(query, slot, cancellationToken: cancellationToken));
            }
        }
    }
}
// var query = "INSERT INTO \"Slots\" " +
//             "(\"IdSlot\", \"Date\", \"StartTime\", \"EndTime\", \"IsFree\") " +
//             "VALUES " +
//             "(@IdSlot, @Date, @StartTime, @EndTime, true)";