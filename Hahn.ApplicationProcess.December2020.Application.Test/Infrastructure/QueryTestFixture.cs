using Hahn.ApplicationProcess.December2020.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Hahn.ApplicationProcess.December2020.Application.Test.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public AppDbContext Context { get; private set; }
        public QueryTestFixture()
        {
            Context = AppDbContextFactory.Create();
        }
        public void Dispose()
        {
            AppDbContextFactory.Destroy(Context);
        }

        [CollectionDefinition("QueryCollection")]
        public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
    }
}
