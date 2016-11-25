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
                );
        }

        public virtual async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if(activity != null && activity.GetActivityType() == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, MakeServiceRequestDialog);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}
