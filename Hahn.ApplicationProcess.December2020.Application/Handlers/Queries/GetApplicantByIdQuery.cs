using FluentValidation;
using Hahn.ApplicationProcess.December2020.Application.Exceptions;
using Hahn.ApplicationProcess.December2020.Application.Interfaces;
using Hahn.ApplicationProcess.December2020.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Application.Handlers.Queries
{
    public class GetApplicantByIdQuery: IRequest<Applicant>
    {
        public int ID { get; set; }
    }

    public class GetApplicantByIdValidator: AbstractValidator<GetApplicantByIdQuery>
    {
        public GetApplicantByIdValidator()
        {
            RuleFor(a => a.ID).NotEmpty();
        }
    }
    public class GetApplicantByIdQueryHandler: IRequestHandler<GetApplicantByIdQuery, Applicant>
    {
        private readonly IAppDbContext _dbContext;
        public GetApplicantByIdQueryHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<Applicant> Handle(GetApplicantByIdQuery request, CancellationToken cancellationToken)
        {
            var applicant = await _dbContext.Applicants.FindAsync(request.ID);
            if (applicant == null)
            {
                throw new NotFoundException(nameof(Applicant), request.ID);
            }
            return applicant;
        }
    }
}
