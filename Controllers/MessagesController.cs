using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Web.Http.Description;
using System.Net.Http;

namespace Microsoft.Bot.Sample.LuisBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// receive a message from a user and send replies
        /// </summary>
        /// <param name="activity"></param>
        [ResponseType(typeof(void))]
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            // check if activity is of type message
            if (activity.GetActivityType() == ActivityTypes.Message)
            {
                //await Conversation.SendAsync(activity, () => new PromptButtonsDialog());
                await Conversation.SendAsync(activity, () => new RootDialog());
                //await Conversation.SendAsync(activity, () => new SimpleQnADialog());
                //await Conversation.SendAsync(activity, () => new BasicLuisDialog());
            }
            else
            {
                HandleSystemMessage(activity);
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                //Greeting
                /*
                if (message.MembersAdded.Any(o => o.Id == message.Recipient.Id))
                {
                    ConnectorClient connector = new ConnectorClient(new Uri(message.ServiceUrl));
                    Activity reply = message.CreateReply("Hello, My name is Athena and I will be your virtual assistant today.");
                    connector.Conversations.ReplyToActivityAsync(reply);

                    //Lets set up the exploration method
                    Conversation.SendAsync(message, () => new PromptButtonsDialog());
                }
                */

                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}