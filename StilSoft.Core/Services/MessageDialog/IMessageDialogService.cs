using System.Threading.Tasks;

namespace StilSoft.Services.MessageDialog
{
    public interface IMessageDialogService
    {
        MessageDialogResult ShowMessage(string title, string message,
            MessageDialogButtons messageButtons = MessageDialogButtons.Ok,
            MessageDialogIcon messageIcon = MessageDialogIcon.None,
            MessageDialogDefaultButton defaultButton = MessageDialogDefaultButton.Button1);

        Task<MessageDialogResult> ShowMessageAsync(string title, string message,
            MessageDialogButtons messageButtons = MessageDialogButtons.Ok,
            MessageDialogIcon messageIcon = MessageDialogIcon.None,
            MessageDialogDefaultButton defaultButton = MessageDialogDefaultButton.Button1);
    }
}