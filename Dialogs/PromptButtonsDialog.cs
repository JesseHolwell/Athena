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
        private const string LuisOption = "LUIS";
        private const string QuestionOption =  "QnA";
        private const string SearchOption  =  "Search";

        private const string MenuQuestion = "Which method would you like me to use?";

        IAwaitable<string> optionSelected;
        string option;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            if (String.IsNullOrEmpty(option))
            {
                //Show options whatever users chat
                
                PromptDialog.Choice(context, this.AfterMenuSelection, new List<string>() { LuisOption, QuestionOption, SearchOption }, MenuQuestion);
            }
            else
            {
                AfterMenuSelection(context, optionSelected);
            }
        }

        //After users select option, Bot call other dialogs
        private async Task AfterMenuSelection(IDialogContext context, IAwaitable<string> result)
        {
            optionSelected = result;
            option = await optionSelected;

            //context.PostAsync(String.Format("Okay I will use the {0} format", option));
            //context.PostAsync("What can I help you with today?");

            switch (option)
            {
                case LuisOption:
                    context.PostAsync(String.Format("Okay I will use the {0} format", option));
                    context.PostAsync("What can I help you with today?");
                    context.Call(new BasicLuisDialog(), ResumeAfterOptionDialog);
                    break;
                case QuestionOption:
                    context.PostAsync(String.Format("Okay I will use the {0} format", option));
                    context.PostAsync("What can I help you with today?");
                    context.Call(new SimpleQnADialog(), ResumeAfterOptionDialog);
                    break;
                case SearchOption:
                    context.PostAsync("Sorry but I don't know how to use the search format yet!");
                    option = null;
                    PromptDialog.Choice(context, this.AfterMenuSelection, new List<string>() { LuisOption, QuestionOption, SearchOption }, MenuQuestion);
                    //context.Wait(this.MessageReceivedAsync);
                    //context.Call(new SearchDialog(), ResumeAfterOptionDialog);
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