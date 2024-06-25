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
    public async Task<List<DateOnly>> GetAvailableDates(CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = "SELECT DISTINCT \"Date\" FROM \"Slot\" WHERE \"IsFree\" = true";
            var slots = await connection.QueryAsync<DateOnly>(
                new CommandDefinition(query, cancellationToken: cancellationToken));
            return slots.ToList();
        }
    }
    public async Task<List<Slot>> GetAvailableSlotsOnDate(DateOnly date, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            // var query1 = "SELECT * FROM \"Slots\" WHERE \"Date\" = @Date AND \"IsFree\" = true";
            var query = CustomQueryBuilder.GetByFiltration(nameof(Slot));
            query.Append(CustomQueryBuilder.AddFilter("Date"));
            query.Append(CustomQueryBuilder.AddFilter("IsFree"));
            query.Append(CustomQueryBuilder.AddOrder(OrderBy.Date, OrderType.Ascending));
            
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
            // var query = "SELECT * FROM \"Slot\" WHERE \"Date\" = @Date AND \"StartTime\" >= @StartTime AND \"EndTime\" <= @EndTime";
            var query = CustomQueryBuilder.GetByFiltration(nameof(Slot));
            query.Append(CustomQueryBuilder.AddFilter("Date"));
            query.Append(CustomQueryBuilder.AddTimeBordersFilter("StartTime", "EndTime"));
            query.Append(CustomQueryBuilder.AddOrder(OrderBy.Date, OrderType.Ascending));

            var parameters = new DynamicParameters();
            parameters.Add("Date", date);
            parameters.Add("StartTime", new TimeSpan(startTime.Hour, startTime.Minute, startTime.Second));
            parameters.Add("EndTime", new TimeSpan(endTime.Hour, endTime.Minute, endTime.Second));
            var slots = await connection.QueryAsync<Slot>(
                new CommandDefinition(query.ToString(), parameters, cancellationToken: cancellationToken));
            return slots.ToList().AsReadOnly();
        }
    }
    public async Task CreateSlots(List<Slot> slots, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            // var query = "INSERT INTO \"Slots\" " +
            //             "(\"IdSlot\", \"Date\", \"StartTime\", \"EndTime\", \"IsFree\") " +
            //             "VALUES " +
            //             "(@IdSlot, @Date, @StartTime, @EndTime, true)";
            var query = CustomQueryBuilder.Create(slots.First());

            foreach (var slot in slots)
            {
                await connection
                    .ExecuteAsync(
                        new CommandDefinition(query, slot, cancellationToken: cancellationToken));
            }
        }
    }
    public async Task ChangeSlotsStatuses(DateOnly date, TimeOnly startTime, TimeOnly endTime, bool status, 
        CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            // var query = "UPDATE \"Slot\" SET \"IsFree\" = @IsFree WHERE \"Date\" = @Date AND \"StartTime\" >= @StartTime AND \"EndTime\" <= @EndTime";
            var query = CustomQueryBuilder.UpdateField(nameof(Slot), "IsFree");
            query.Append(CustomQueryBuilder.Filtration);
            query.Append(CustomQueryBuilder.AddFilter("Date"));
            query.Append(CustomQueryBuilder.AddTimeBordersFilter("StartTime", "EndTime"));

            var parameters = new DynamicParameters();
            parameters.Add("IsFree", status);
            parameters.Add("Date", date);
            parameters.Add("StartTime", new TimeSpan(startTime.Hour, startTime.Minute, startTime.Second));
            parameters.Add("EndTime", new TimeSpan(endTime.Hour, endTime.Minute, endTime.Second));
            await connection
                .ExecuteAsync(
                    new CommandDefinition(query.ToString(), parameters, cancellationToken: cancellationToken));
        }
    }
}