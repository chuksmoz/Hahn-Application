using Hahn.ApplicationProcess.December2020.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.December2020.Application.Test.Infrastructure
{
    public class CommandTestBase: IDisposable
    {
        protected readonly AppDbContext _context;

        public CommandTestBase()
        {
            _context = AppDbContextFactory.Create();
        }

        public void Dispose()
        {
            AppDbContextFactory.Destroy(_context);
        }
    }
}
