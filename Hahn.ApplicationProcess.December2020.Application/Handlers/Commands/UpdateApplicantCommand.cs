using FluentValidation;
using Hahn.ApplicationProcess.December2020.Application.Exceptions;
using Hahn.ApplicationProcess.December2020.Application.Interfaces;
using Hahn.ApplicationProcess.December2020.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Application.Handlers.Commands
{
    public class UpdateApplicantCommand: IRequest<Unit>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }
    }
    public class UpdateApplicantCommandQueryValidator : AbstractValidator<UpdateApplicantCommand>
    {
        public UpdateApplicantCommandQueryValidator()
        {
            RuleFor(a => a.ID).NotEmpty();
            RuleFor(a => a.Name)
                .NotEmpty()
                .MinimumLength(5);
            RuleFor(a => a.FamilyName)
                .NotEmpty()
                .MinimumLength(5);
            RuleFor(a => a.Address)
                .NotEmpty()
                .MinimumLength(10);
            RuleFor(a => a.EmailAddress)
                .NotEmpty()
                .EmailAddress();
            RuleFor(a => a.Age)
                .NotEmpty()
                .InclusiveBetween(20, 60);
        }
    }

    public class UpdateApplicantCommandQueryHandler : IRequestHandler<UpdateApplicantCommand, Unit>
    {
        private readonly IAppDbContext _dbContext;
        public UpdateApplicantCommandQueryHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _dbContext.Applicants.SingleOrDefaultAsync(a => a.ID == request.ID);
            if (applicant == null)
            {
               throw new NotFoundException(nameof(Applicant), request.ID);
            }

            applicant.FamilyName = request.FamilyName;
            applicant.Name = request.Name;
            applicant.CountryOfOrigin = request.CountryOfOrigin;
            applicant.Address = request.Address;
            applicant.Hired = request.Hired;
            applicant.Age = request.Age;
            applicant.EmailAddress = request.EmailAddress;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
