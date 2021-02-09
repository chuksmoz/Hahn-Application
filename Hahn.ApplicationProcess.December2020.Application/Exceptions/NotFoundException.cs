using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Application.Exceptions
{
   public class NotFoundException: Exception
   {
        //private readonly ILogger _logger;
        public NotFoundException()
        {
            //_logger = logger;
        }
        public NotFoundException(string name, object key)
            : base(string.Format("Entity {0} ({1}) was not found.", name, key))
        {
            //_logger.LogError("FAILD", name);
        }
    }
}
