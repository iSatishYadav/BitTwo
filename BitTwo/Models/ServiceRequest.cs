using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitTwo.Models
{
    public enum RequestType
    {
        Software, Hardware, Network, Others
    }

    [Serializable]
    public class ServiceRequest
    {
        public RequestType Type { get; set; }
        public string Description { get; set; }

        public static IForm<ServiceRequest> CreateServiceRequestForm()
        {
            return new FormBuilder<ServiceRequest>()
                .Message("Welcome to BitTwo")
                .Build();
        }
    }
}