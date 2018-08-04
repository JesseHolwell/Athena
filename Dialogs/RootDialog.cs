using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Threading;

namespace Microsoft.Bot.Sample.LuisBot
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Root Dialog - Message received");
            //var activity = await result as Activity;
            //await context.Forward(new LuisDialog(), this.ResumeAfterLuisDialog, activity, CancellationToken.None);

            context.Call(new LuisDialog(), ResumeAfterOptionDialog);

        }

        /// <summary>
        /// You can handle things after LUIS give the answer
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task ResumeAfterLuisDialog(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Root Dialog - After dialog");
            var ticketNumber = await result;
            //Do nothing until user send another message
            context.Wait(this.MessageReceivedAsync);
        }

        //This function is called after each dialog process is done
        private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {
            //This means  MessageRecievedAsync function of this dialog (PromptButtonsDialog) will receive users' messeges
            context.Wait(MessageReceivedAsync);
        }
    }
}