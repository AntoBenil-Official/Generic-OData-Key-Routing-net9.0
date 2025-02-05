using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;

namespace GenericControllerTest.Middleware.Routing
{
    public class GenericControllerApplicationPart : ApplicationPart, IApplicationPartTypeProvider
    {
        public GenericControllerApplicationPart(Type controllerType)
        {
            Types = new[] { controllerType.GetTypeInfo() };
        }

        public override string Name => "GenericControllerPart";

        public IEnumerable<TypeInfo> Types { get; }
    }

}
