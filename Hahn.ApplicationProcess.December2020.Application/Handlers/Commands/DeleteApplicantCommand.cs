using FluentValidation;
using Hahn.ApplicationProcess.December2020.Application.Exceptions;
using Hahn.ApplicationProcess.December2020.Application.Interfaces;
using Hahn.ApplicationProcess.December2020.Common;
using Hahn.ApplicationProcess.December2020.Common.Models;
using Hahn.ApplicationProcess.December2020.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Application.Handlers.Commands
{
    public class DeleteApplicantCommand :IRequest<Unit>
    {
        public int ID { get; set; }
    }

    public class DeleteApplicantCommandQueryValidator : AbstractValidator<DeleteApplicantCommand>
    {
        public DeleteApplicantCommandQueryValidator()
        {
            RuleFor(a => a.ID).NotEmpty();
        }
    }

    public class DeleteApplicantCommandQueryHandler : IRequestHandler<DeleteApplicantCommand, Unit>
    {
        private readonly IAppDbContext _dbContext;
        public DeleteApplicantCommandQueryHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _dbContext.Applicants.FindAsync(request.ID);
            if (applicant == null)
            {
                throw new NotFoundException(nameof(Applicant), request.ID);
                
            }

            _dbContext.Applicants.Remove(applicant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
