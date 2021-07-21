using System;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client.Js.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
