using Hahn.ApplicationProcess.December2020.Application.Exceptions;
using Hahn.ApplicationProcess.December2020.Application.Handlers.Commands;
using Hahn.ApplicationProcess.December2020.Application.Test.Infrastructure;
using Hahn.ApplicationProcess.December2020.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Hahn.ApplicationProcess.December2020.Application.Test.Handlers.Commands
{
    public class DeleteApplicantCommandTest: CommandTestBase
    {
        [Fact]
        public void Handle_GivenValidRequest_ShouldDeleteApplicant()
        {
            // Arrange            
            var sut = new DeleteApplicantCommandQueryHandler(_context);

            // Act
            var result = sut.Handle(new DeleteApplicantCommand { ID = 1 }, CancellationToken.None);


            // Assert
            result.Result.Equals(Unit.Value);
        }

        [Fact]
        public async Task Handle_GivenInValidRequestId_ShouldThrowNotFoundException()
        {
            // Arrange
            var sut = new DeleteApplicantCommandQueryHandler(_context);
            var id = 100;
            var request = new DeleteApplicantCommand { ID = id };


            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(request, CancellationToken.None));
        }
    }
}
