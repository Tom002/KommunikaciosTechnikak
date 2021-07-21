using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using KommunikaciosTechnikak.Dal.Model;
using System.Reflection;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<AdventureWorks2019Context>();
        }
    }
}
