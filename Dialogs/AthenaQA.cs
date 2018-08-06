using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using System;
using System.Configuration;

namespace Athena
{
    [Serializable]
    public class AthenaQA : QnAMakerDialog
    {
        public AthenaQA() : base(new QnAMakerService(new QnAMakerAttribute(
            ConfigurationManager.AppSettings["QnAKey"],
            ConfigurationManager.AppSettings["QnAId"],
            "Sorry but I was unable to find an answer",
            0.3, 1, "https://athena-qa.azurewebsites.net/qnamaker"
            )))
        {
        }
    }
}