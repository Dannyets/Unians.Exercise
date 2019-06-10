using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Api.Interfaces
{
    public interface INotificationService
    {
        Task PublishMessage<T>(T message);
    }
}
