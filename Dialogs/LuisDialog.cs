using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace Microsoft.Bot.Sample.LuisBot
{
    [LuisModel("6e450b31-972b-4af6-9a52-c77faa79860e", "9755833599da4448bebbceff5655a62a", LuisApiVersion.V2, "australiaeast.api.cognitive.microsoft.com")]

    [Serializable]
    public class LuisDialog : LuisDialog<object>
    {
        /// <summary>
        /// LUIS Logic
        /// </summary>
       
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Luis Dialog - Found {result.Intents[0].Intent}. Query: {result.Query}");
            
            // No intent found, then try asking QnA Knowlegebase
            context.Call(new SimpleQnADialog(), ResumeAfterOptionDialog);
        }

        //This function is called after each dialog process is done
        private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {
            //await context.PostAsync("Luis Dialog - After dialog");            
        }
    }
}