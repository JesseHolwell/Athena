using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Athena
{
    [Serializable]
    public class AthenaLUIS : LuisDialog<object>
    {
        public AthenaLUIS() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"], 
            ConfigurationManager.AppSettings["LuisAPIKey"]
            //, domain: ConfigurationManager.AppSettings["LuisAPIHostName"]
            )))
        {
        }

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            //context.Call(new AthenaQA(), MessageReceived);
            //await this.ShowLuisResult(context, result);

            await context.PostAsync($"You have reached {result.Intents[0].Intent}.");

            // No intent found, then try asking QnA Knowlegebase
            context.Call(new AthenaQA(), ResumeAfterOptionDialog);
        }

        // Go to https://luis.ai and create a new intent, then train/publish your luis app.
        // Finally replace "Greeting" with the name of your newly created intent in the following handler
        [LuisIntent("Greeting")]
        public async Task GreetingIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        }

        [LuisIntent("Help")]
        public async Task HelpIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        }

        [LuisIntent("Email")]
        public async Task EmailIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached the email intent. From here we can fire off an email with what you have just said: " + result.Query);
            await this.ShowLuisResult(context, result);
        }

        private async Task ShowLuisResult(IDialogContext context, LuisResult result) 
        {
            await context.PostAsync($"You have reached {result.Intents[0].Intent}.");
            context.Wait(MessageReceived);
        }

        //This function is called after each dialog process is done
        private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {
            //await context.PostAsync("Luis Dialog - After dialog");            
        }
    }
}