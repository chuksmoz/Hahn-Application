using Hahn.ApplicationProcess.December2020.Application.Interfaces;
using Hahn.ApplicationProcess.December2020.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Application.Handlers.Queries
{
    public class GetAllApplicantQuery: IRequest<List<Applicant>>
    {
    }

    public class GetAllApplicantQueryHandler: IRequestHandler<GetAllApplicantQuery, List<Applicant>>
    {
        private readonly IAppDbContext _dbContext;
        public GetAllApplicantQueryHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Applicant>> Handle(GetAllApplicantQuery request, CancellationToken cancellationToken)
        {
            var res = await _dbContext.Applicants.ToListAsync(cancellationToken);
            return res;
        }
    }
}
