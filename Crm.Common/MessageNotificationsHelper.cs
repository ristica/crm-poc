using Crm.Common.Contracts;

namespace Crm.Common;

public sealed class MessageNotificationsHelper : IMessageNotificationsHelper
{
    private readonly Dictionary<int, List<IReceiver>> _subscribers;

    public MessageNotificationsHelper()
    {
        _subscribers = new Dictionary<int, List<IReceiver>>();
    }

    public void Subscribe(IReceiver receiver, int messageId)
    {
        if (_subscribers.TryGetValue(messageId, out var receivers))
            receivers.Add(receiver);
        else
            _subscribers.Add(messageId, new List<IReceiver>() { receiver });
    }

    public void Publish<T>(object sender, T args, int messageId) where T : EventArgs
    {
        if (!_subscribers.TryGetValue(messageId, out var receivers)) return;
        foreach (var receiver in receivers)
        {
            if (!(receiver is IReceiver<T> receiverToReceive)) continue;
            receiverToReceive.Receive(sender, args, messageId);
        }
    }

    public void Unsubscribe(IReceiver receiver, int messageId)
    {
        if (!_subscribers.TryGetValue(messageId, out var receivers)) return;
        if (receivers.Count > 1)
            receivers.Remove(receiver);
        else if (receivers.Count == 1) _subscribers.Remove(messageId);
    }

    public void Dispose()
    {
        _subscribers.Clear();
    }
}