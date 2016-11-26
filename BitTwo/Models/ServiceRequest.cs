using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitTwo.Models
{
    public enum RequestType
    {
        Software = 1, Hardware, Network, Others
    }

    [Serializable]
    public class ServiceRequest
    {
        [Prompt("We know it sucks, but what would be the best category to describe your problem?{||}", ChoiceFormat ="{1}")]
        public RequestType Type { get; set; }
        [Prompt("Could you please describe a little about the issue?")]
        public string Description { get; set; }

        public static IForm<ServiceRequest> CreateServiceRequestForm()
        {
            return new FormBuilder<ServiceRequest>()
                .Message("Welcome to BitTwo")
                .Build();
        }
    }
}