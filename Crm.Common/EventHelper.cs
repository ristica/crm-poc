using Crm.Common.Contracts;

namespace Crm.Common
{
    public class EventHelper : IEventHelper
    {
        public void RaiseEvent(
            object objectRaisingEvent,
            EventHandler? eventHandlerRaised,
            EventArgs eventArgs)
        {
            eventHandlerRaised?.Invoke(objectRaisingEvent, eventArgs);
        }
    }
}
