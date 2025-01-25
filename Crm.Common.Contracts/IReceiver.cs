namespace Crm.Common.Contracts;

public interface IReceiver<in T> : IReceiver where T : EventArgs
{
    void Receive(object sender, T args, int messageId);
}

public interface IReceiver : IDisposable
{
    // intentionally left blank ...
}