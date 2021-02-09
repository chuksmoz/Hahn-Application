using FluentValidation;
using Hahn.ApplicationProcess.December2020.Application.Exceptions;
using Hahn.ApplicationProcess.December2020.Application.Interfaces;
using Hahn.ApplicationProcess.December2020.Common.Models;
using Hahn.ApplicationProcess.December2020.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Application.Handlers.Commands
{
    public class AddAplicantCommand : IRequest<Applicant>
    {
        
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }
    }

    public class AddAplicantCommandQueryValidator : AbstractValidator<AddAplicantCommand>
    {
        public AddAplicantCommandQueryValidator()
        {
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

    public class AddAplicantCommandQueryHandler : IRequestHandler<AddAplicantCommand, Applicant>
    {
        private readonly ICountryValidatorService _countryValidatorService;
        private readonly IAppDbContext _dbContext;
        //private readonly ILogger<AddAplicantCommandQueryHandler> _logger;
        public AddAplicantCommandQueryHandler(IAppDbContext dbContext, ICountryValidatorService countryValidatorService)
        {
            _dbContext = dbContext;
            _countryValidatorService = countryValidatorService;
            //_logger = logger;
        }
        public async Task<Applicant> Handle(AddAplicantCommand request, CancellationToken cancellationToken)
        {
            MessageResponse<Applicant> messageResponse = new MessageResponse<Applicant>();

            //_logger.LogInformation("START", request);
            var isCountryValid = await _countryValidatorService.ValidateCountryByName(request.CountryOfOrigin);
            if (!isCountryValid)
            {
                throw new NotFoundException(nameof(Applicant), request.CountryOfOrigin);
            }

            var applicant = new Applicant()
            {
                
                Age = request.Age,
                Address = request.Address,
                CountryOfOrigin = request.CountryOfOrigin,
                EmailAddress = request.EmailAddress,
                FamilyName = request.FamilyName,
                Hired = request.Hired,
                Name = request.Name
            };
            _dbContext.Applicants.Add(applicant);
            await _dbContext.SaveChangesAsync(cancellationToken);
           // _logger.LogInformation("SAVED", applicant);
            return applicant;
        }
    }
}
