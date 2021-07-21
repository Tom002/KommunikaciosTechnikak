using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Common
{
    public abstract class Payload
    {
        protected Payload(IReadOnlyList<UserError>? errors = null)
        {
            Errors = errors;
        }

        public IReadOnlyList<UserError>? Errors { get; }
    }
}
