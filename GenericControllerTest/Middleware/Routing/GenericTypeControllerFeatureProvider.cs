using GenericControllerTest.Common;
using GenericControllerTest.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;

namespace GenericControllerTest.Middleware.Routing
{
    public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var controllerTypes = MfgCommon.GetTypesInNamespace()
                .Select(entityType => new
                {
                    EntityType = entityType,
                    ControllerType = typeof(ManufacturingController<>).MakeGenericType(entityType).GetTypeInfo()
                })
                .Where(t => !feature.Controllers.Any(c => c.Name == t.EntityType.Name + "Controller"));

            foreach (var controllerType in controllerTypes)
            {
                feature.Controllers.Add(controllerType.ControllerType);
            }
        }
    }
}
