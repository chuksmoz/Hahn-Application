using Hahn.ApplicationProcess.December2020.Application.Handlers.Commands;
using Hahn.ApplicationProcess.December2020.Application.Interfaces;
using Hahn.ApplicationProcess.December2020.Application.Test.Infrastructure;
using Shouldly;
using Hahn.ApplicationProcess.December2020.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Application.Test.Handlers.Commands
{
    public class AddAplicantCommandTest: CommandTestBase
    {
        [Fact]
        public async void Handle_GivenValidRequest_ShouldCreateApplicant()
        {
            // Arrange            
            var _countryValidatorService = new Mock<ICountryValidatorService>();
            _countryValidatorService.Setup(x => x.ValidateCountryByName(It.IsAny<string>())).Returns(Task.FromResult(true));
            var sut = new AddAplicantCommandQueryHandler(_context, _countryValidatorService.Object);
            var applicant = new AddAplicantCommand() 
            {
                Address = "1 some address in germany",
                Age = 20,
                CountryOfOrigin = "Nigeria",
                EmailAddress = "test@test.com",
                FamilyName = "Obika",
                Hired = true,
                Name = "Moses",
                //ID = 10
            };

            
                 

            // Act
            var result = await sut.Handle(applicant, CancellationToken.None);


            // Assert
            result.ShouldBeOfType<Applicant>();
        }


    }
}
