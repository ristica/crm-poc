using System.Windows.Input;

// https://devblogs.microsoft.com/dotnet/winforms-cross-platform-dotnet-maui-command-binding/
// https://www.infoq.com/news/2023/02/winforms-binding-mvvm-net-7/
namespace Crm.Common.Utility;

public class RelayCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    private readonly Action _commandAction;
    private readonly Func<bool>? _canExecuteCommandAction;

    public RelayCommand(
        Action commandAction,
        Func<bool>? canExecuteCommandAction = null)
    {
        _commandAction = commandAction ?? throw new ArgumentNullException(nameof(commandAction));
        _canExecuteCommandAction = canExecuteCommandAction;
    }

    bool ICommand.CanExecute(object? parameter)
    {
        return _canExecuteCommandAction is null || _canExecuteCommandAction.Invoke();
    }

    void ICommand.Execute(object? parameter)
    {
        _commandAction.Invoke();
    }

    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}