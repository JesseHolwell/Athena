using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace Microsoft.Bot.Sample.LuisBot
{
    [Serializable]
    //This is actually Root Dialog of this bot, but I named PromptButtons Dialog becuase I want to set similar name in node.js sample.
    public class PromptButtonsDialog : IDialog<object>
    {
        private const string ExplorerOption = "LUIS";
        private const string QuestionOption =  "QnA";
        private const string SearchOption  =  "Search";

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hey there beautiful");
            context.Wait(this.MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            //Show options whatever users chat
            PromptDialog.Choice(context, this.AfterMenuSelection, new List<string>() {ExplorerOption, QuestionOption}, "How would you like to explore the data?");
        }

        //After users select option, Bot call other dialogs
        private async Task AfterMenuSelection(IDialogContext context, IAwaitable<string> result)
        {
            var optionSelected = await result;
            context.PostAsync("you said " + optionSelected);

            switch(optionSelected)
            {
                case ExplorerOption:
                    context.Call(new BasicLuisDialog(), ResumeAfterOptionDialog);
                    break;
                case QuestionOption:
                    context.Call(new SimpleQnADialog(), ResumeAfterOptionDialog);
                    break;
                case SearchOption:
                    context.Call(new SearchDialog(), ResumeAfterOptionDialog);
                    break;
            }

        }

        //This function is called after each dialog process is done
        private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {
            //This means  MessageRecievedAsync function of this dialog (PromptButtonsDialog) will receive users' messeges
            context.Wait(MessageReceivedAsync);
        }
    }
}