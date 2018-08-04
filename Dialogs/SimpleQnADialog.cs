using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Diagnostics;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;

namespace Microsoft.Bot.Sample.LuisBot
{
    [Serializable]
    // Below method uses the V2 APIs : https://aka.ms/qnamaker-v2-apis. 
    // To use V4 stack, you also need to add the Endpoint hostname to the parameters below : https://aka.ms/qnamaker-v4-apis
    [QnAMaker("cb4ef4f1-0fba-4c04-99c7-f90fc42bbf24", "bd32b467-38a9-4308-92dc-1f5198cf76e5", "Sorry but I was unable to an answer to this query.", 0.3, 1, "https://athena-qa.azurewebsites.net/qnamaker")]
    public class SimpleQnADialog : QnAMakerDialog
    {
    }

}