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
    [QnAMaker("b2ec10b0-2d23-486a-beac-70c446db1e99", "4f4166db-26c3-4491-b2e5-e28ce61b7d71", "Sorry but I was unable to an answer to this query.", 0.3, 1, "https://hellaqa.azurewebsites.net/")]
    public class SimpleQnADialog : QnAMakerDialog
    {
    }

}