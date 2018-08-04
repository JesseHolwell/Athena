using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace Microsoft.Bot.Sample.LuisBot
{
    [LuisModel("befeae78-cb33-4a46-a483-b50067712757", "b7620bcae0f847d69422ee5b908a9edb", LuisApiVersion.V2)]
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