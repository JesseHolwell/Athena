using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace Microsoft.Bot.Sample.LuisBot
{
    //[Serializable]
    ////This is actually Root Dialog of this bot, but I named PromptButtons Dialog becuase I want to set similar name in node.js sample.
    //public class PromptButtonsDialog : IDialog<object>
    //{
    //    private const string LuisOption = "LUIS";
    //    private const string QuestionOption =  "QnA";

    //    private const string MenuQuestion = "Which method would you like me to use?";

    //    IAwaitable<string> optionSelected;
    //    string option;

    //    public async Task StartAsync(IDialogContext context)
    //    {
    //        context.Wait(this.MessageReceivedAsync);
    //    }

    //    public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
    //    {
    //        if (String.IsNullOrEmpty(option))
    //        {                
    //            PromptDialog.Choice(context, this.AfterMenuSelection, new List<string>() { LuisOption, QuestionOption }, MenuQuestion);
    //        }
    //        else
    //        {
    //            AfterMenuSelection(context, optionSelected);
    //        }
    //    }

    //    //After users select option, Bot call other dialogs
    //    private async Task AfterMenuSelection(IDialogContext context, IAwaitable<string> result)
    //    {
    //        optionSelected = result;
    //        option = await optionSelected;

    //        switch (option)
    //        {
    //            case LuisOption:
    //                context.PostAsync(String.Format("Okay I will use the {0} format", option));
    //                context.PostAsync("What can I help you with today?");
    //                context.Call(new BasicLuisDialog(), ResumeAfterOptionDialog);
    //                break;
    //            case QuestionOption:
    //                context.PostAsync(String.Format("Okay I will use the {0} format", option));
    //                context.PostAsync("What can I help you with today?");
    //                context.Call(new SimpleQnADialog(), ResumeAfterOptionDialog);
    //                break;
    //        }

    //    }

    //    //This function is called after each dialog process is done
    //    private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
    //    {
    //        context.Wait(MessageReceivedAsync);
    //    }
    //}
}