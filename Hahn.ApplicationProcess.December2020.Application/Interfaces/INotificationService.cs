using Hahn.ApplicationProcess.December2020.Application.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
