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
    [Collection("QueryCollection")]
    public class GetAllApplicantQueryHandlerTests
    {
        private readonly AppDbContext _context;

        public GetAllApplicantQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetAllApplicant()
        {
            var sut = new GetAllApplicantQueryHandler(_context);

            var result = await sut.Handle(new GetAllApplicantQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<Applicant>>();
            //result.Count.ShouldBe(3);
        }
    }
}
