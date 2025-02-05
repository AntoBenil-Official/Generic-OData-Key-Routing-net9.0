using GenericControllerTest.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.OData.Routing.Template;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace GenericControllerTest.Middleware.Routing
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GenericControllerNameAttribute : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.IsGenericType &&
                controller.ControllerType.GetGenericTypeDefinition() == typeof(ManufacturingController<>))
            {
                var entityType = controller.ControllerType.GenericTypeArguments[0];
                controller.ControllerName = entityType.Name;

                // Clear existing selectors
                controller.Selectors.Clear();

                // Define the base OData route pattern (collection-level route)
                var baseRouteTemplate = $"odata/{entityType.Name}";
                var entityKeyRouteTemplate = $"odata/{entityType.Name}({{key}})";

                // Add selector for base route
                var selectorModelBase = new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(baseRouteTemplate))
                };
                controller.Selectors.Add(selectorModelBase);

                // Add selector for entity key route
                var selectorModelEntityKey = new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(entityKeyRouteTemplate))
                };
                controller.Selectors.Add(selectorModelEntityKey);

                // Retrieve EDM Model for OData
                var model = ODataEDMBuilder.GetEdmModel();
                var pathTemplateBase = new ODataPathTemplate(new GenericODataTemplate($"{entityType.Name}"));
                var pathTemplateEntityKey = new ODataPathTemplate(new GenericODataTemplate($"{entityType.Name}({{key}})"));

                ODataRoutingMetadata odataMetadataBase = new ODataRoutingMetadata("odata", model, pathTemplateBase);
                ODataRoutingMetadata odataMetadataEntityKey = new ODataRoutingMetadata("odata", model, pathTemplateEntityKey);

                // Add OData metadata to the selectors for enhanced OData functionality
                selectorModelBase.EndpointMetadata.Add(odataMetadataBase);
                selectorModelEntityKey.EndpointMetadata.Add(odataMetadataEntityKey);
            }
        }
    }
}