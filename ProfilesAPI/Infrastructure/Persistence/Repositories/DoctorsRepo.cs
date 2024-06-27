﻿using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces.ReposInterfaces;
using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories;

public class DoctorsRepo(ProfilesDbContext _context)
    : IDoctorsRepo
{
    public async Task<IReadOnlyCollection<Doctor>> GetDoctorsByFiltration(
        PageSettings pageSettings, DoctorFilters filters, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.GetByFiltration(nameof(Doctor));

            if (!string.IsNullOrEmpty(filters.FullName))
                query.Append(CustomQueryBuilder.AddFullNameFilter(filters.FullName));
            if (filters.IdSpecialization != Guid.Empty && filters.IdSpecialization != null) 
                query.Append(CustomQueryBuilder.AddFilter(nameof(filters.IdSpecialization)));
            if (filters.IdOffice != Guid.Empty && filters.IdOffice != null) 
                query.Append(CustomQueryBuilder.AddFilter(nameof(filters.IdOffice)));
            
            query.Append(CustomQueryBuilder.AddFilter(nameof(filters.Status)));
            query.Append(CustomQueryBuilder.AddOrder(filters.OrderBy, filters.OrderType));
            query.Append(CustomQueryBuilder.Pagination);
            
            var parameters = new DynamicParameters(filters);
            parameters.Add(nameof(pageSettings.Page), pageSettings.Page);
            parameters.Add(nameof(pageSettings.PageSize), pageSettings.PageSize);
            var doctors = await connection.QueryAsync<Doctor>(
                new CommandDefinition(query.ToString(), parameters, cancellationToken: cancellationToken));
            return doctors.ToList().AsReadOnly();
        }
    }

    public async Task<Doctor> GetDoctorById(
        Guid idDoctor, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.GetById(nameof(Doctor));
            var doctor = await connection.QueryFirstOrDefaultAsync<Doctor>(
                new CommandDefinition(query, new { idDoctor }, cancellationToken: cancellationToken));
            return doctor;
        }
    }

    public async Task CreateDoctor(
        Doctor doctor, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.Create(doctor);
            await connection.ExecuteAsync(
                new CommandDefinition(query, doctor, cancellationToken: cancellationToken));
        }
    }

    public async Task UpdateDoctor(Doctor doctor, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = CustomQueryBuilder.UpdateById(doctor);
            await connection.ExecuteAsync(
                new CommandDefinition(query, doctor, cancellationToken: cancellationToken));
        }
    }
}