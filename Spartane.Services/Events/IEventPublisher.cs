using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Events
{
    /// <summary>
    /// Event publisher
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// Publish event
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="eventMessage">Event message</param>
        void Publish<T>(T eventMessage);
    }
}
