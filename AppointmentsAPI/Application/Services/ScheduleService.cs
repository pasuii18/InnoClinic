using Application.Interfaces;
using Application.Interfaces.RepoInterfaces;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.Services;

public class ScheduleService(IServiceProvider serviceProvider) : IHostedService, IDisposable
{
    private Timer? _timer;
    private const int ScheduledDays = 21;
    private const int DaysToSchedule = 7;
    private readonly TimeOnly _startDayTime = new(8, 0);
    private readonly TimeOnly _endDayTime = new(18, 0);
    private readonly TimeOnly _reducedStartTime = new(9, 0);
    private readonly TimeOnly _reducedEndTime = new(14, 0);
    private const int TimeSlotSize = 10;
    private readonly List<DateOnly> _holidays = GetHolidays(DateTime.Now.Year);

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var startDate = DateOnly.FromDateTime(DateTime.Today);
        var endDate = DateOnly.FromDateTime(DateTime.Today.AddDays(ScheduledDays + DaysToSchedule));

        CreateSlots(startDate, endDate, _startDayTime, _endDayTime, TimeSlotSize, cancellationToken, false).Wait(cancellationToken);

        var nextSunday = GetNextSunday();
        var timeToNextSundayMidnight = nextSunday - DateTime.Now;
        
        _timer = new Timer(ExecuteTask, null, timeToNextSundayMidnight, TimeSpan.FromDays(7));

        return Task.CompletedTask;
    }
    private void ExecuteTask(object? state)
    {
        var startDate = DateOnly.FromDateTime(DateTime.Today.AddDays(ScheduledDays));
        var endDate = DateOnly.FromDateTime(DateTime.Today.AddDays(ScheduledDays + DaysToSchedule));

        CreateSlots(startDate, endDate, _startDayTime, _endDayTime, TimeSlotSize, CancellationToken.None).Wait();
    }
    private async Task CreateSlots(DateOnly startDate, DateOnly endDate, 
        TimeOnly startDayTime, TimeOnly endDayTime, int timeSlotSize, CancellationToken cancellationToken,
        bool isTimerCalled = true)
    {
        var slots = new List<Slot>();
        var dates = new List<DateOnly>();
        using (var scope = serviceProvider.CreateScope())
        {
            var slotRepo = scope.ServiceProvider.GetRequiredService<ISlotRepo>();
            var scheduledDates = await slotRepo.GetDates(cancellationToken);
            for (var currentDate = startDate; currentDate < endDate; currentDate = currentDate.AddDays(1))
            {
                if (currentDate.DayOfWeek == DayOfWeek.Sunday || 
                    _holidays.Contains(currentDate) ||
                    scheduledDates.Contains(currentDate))
                {
                    continue;
                }

                var currentStartTime = startDayTime;
                var currentEndTime = endDayTime;

                if (currentDate.DayOfWeek == DayOfWeek.Saturday || (_holidays.Contains(currentDate.AddDays(1))))
                {
                    currentStartTime = _reducedStartTime;
                    currentEndTime = _reducedEndTime;
                }

                for (var currentTime = currentStartTime; currentTime.AddMinutes(timeSlotSize) <= currentEndTime; 
                     currentTime = currentTime.AddMinutes(timeSlotSize))
                {
                    slots.Add(new Slot { IdSlot = Guid.NewGuid(), Date = currentDate,
                        StartTime = currentTime, EndTime = currentTime.AddMinutes(timeSlotSize) });
                }

                if (isTimerCalled) dates.Add(currentDate.AddDays(-(DaysToSchedule + ScheduledDays)));
            }
           
            if(slots.Any()) await slotRepo.ScheduleSlots(slots, dates, cancellationToken);
        }
    }

    private DateTime GetNextSunday()
    {
        var today = DateTime.Today;
        int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
        return today.AddDays(daysUntilSunday);
    }
    private static List<DateOnly> GetHolidays(int year)
    {
        var holidays = new List<DateOnly>
        {
            new DateOnly(year, 1, 1),
            new DateOnly(year, 1, 7),
            new DateOnly(year, 3, 8),
            new DateOnly(year, 5, 1),
            new DateOnly(year, 5, 9),
            new DateOnly(year, 7, 3),
            new DateOnly(year, 8, 18),
            new DateOnly(year, 11, 7),
            new DateOnly(year, 12, 25)
        };
        
        return holidays;
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }
    public void Dispose()
    {
        _timer?.Dispose();
    }
}