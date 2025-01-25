namespace Crm.Common.Contracts;

public interface IMessageNotificationsHelper : IDisposable
{
    void Subscribe(IReceiver receiver, int messageId);
    void Unsubscribe(IReceiver receiver, int messageId);
    void Publish<T>(object sender, T args, int messageId) where T : EventArgs;
}