using BitTwo.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BitTwo.Controllers
{
    public class ServiceRequestController : ApiController
    {
        internal static IDialog<ServiceRequest> MakeServiceRequestDialog()
        {
            return Chain.From(
                () => FormDialog.FromForm(ServiceRequest.CreateServiceRequestForm)
                .Do(async (context, serviceRequest) =>
                {
                    var completed = await serviceRequest;
                    var id = CreateServiceRequest(completed.Type, completed.Description);
                    await context.PostAsync($"Don't worry, we've created a Service Request. Please note this id {id}, and FM Engineer will contact you very soon. :) ");
                }
                ));
        }

        private static Guid CreateServiceRequest(RequestType type, string description)
        {
            return Guid.NewGuid();
        }

        public async Task<HttpResponseMessage> Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        public virtual async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity != null && activity.GetActivityType() == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, MakeServiceRequestDialog);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            if (activity != null && activity.GetActivityType() == ActivityTypes.ConversationUpdate)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}
