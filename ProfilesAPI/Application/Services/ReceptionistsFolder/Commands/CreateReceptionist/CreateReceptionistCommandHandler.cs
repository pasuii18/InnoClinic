﻿using System.Net;
using Application.Common;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Commands.CreateReceptionist;

public class CreateReceptionistCommandHandler(IReceptionistsRepo _receptionistsRepo)
    : IRequestHandler<CreateReceptionistCommand, ICustomResult>
{
    public async Task<ICustomResult> Handle(CreateReceptionistCommand request, CancellationToken cancellationToken)
    {
        var receptionist = CreateReceptionistCommand.MapInReceptionist(request);
        await _receptionistsRepo.CreateReceptionist(receptionist, cancellationToken);
        
        return new CustomResult(true, Messages.ReceptionistCreated, HttpStatusCode.OK, receptionist.IdReceptionist);
    }
}