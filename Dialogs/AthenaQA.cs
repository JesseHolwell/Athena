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
            "Hmm, I wasn't able to find an article about that. Can you try asking in a different way?",
            0.3, 1, "https://athena-qa.azurewebsites.net/qnamaker"
            )))
        {
        }
    }
}