using Hahn.ApplicationProcess.December2020.Application.Handlers.Queries;
using Hahn.ApplicationProcess.December2020.Application.Test.Infrastructure;
using Hahn.ApplicationProcess.December2020.Data;
using Hahn.ApplicationProcess.December2020.Domain.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Hahn.ApplicationProcess.December2020.Application.Test.Handlers.Queries
{
    public class GetApplicantByIdQueryHandlerTest
    {
        private readonly AppDbContext _context;

        public GetApplicantByIdQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetApplicantById()
        {
            var sut = new GetApplicantByIdQueryHandler(_context);

            var result = await sut.Handle(new GetApplicantByIdQuery { ID = 1 }, CancellationToken.None);


            result.ShouldBeOfType<Applicant>();
        }
    }
}
