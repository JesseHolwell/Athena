using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;

namespace Athena
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
            //await context.PostAsync("Root Dialog - Message received");
            //var activity = await result as Activity;
            //await context.Forward(new LuisDialog(), this.ResumeAfterLuisDialog, activity, CancellationToken.None);

            context.Call(new AthenaLUIS(), ResumeAfterLuisDialog);

        }

        /// <summary>
        /// You can handle things after LUIS give the answer
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task ResumeAfterLuisDialog(IDialogContext context, IAwaitable<object> result)
        {
            //await context.PostAsync("Root Dialog - After dialog");
            //var ticketNumber = await result;
            //Do nothing until user send another message
            context.Wait(MessageReceivedAsync);
        }
    }
}