using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Routing.Conventions;

namespace GenericControllerTest.Middleware.Routing
{
    public class OdataControllerBaseRoutingConvention : IODataControllerActionConvention
    {
        public int Order => 100; // Ensures it runs after built-in conventions

        public bool AppliesToController(ODataControllerActionContext context)
        {
            // Apply this convention only to OData controllers
            return context.Controller.ControllerType.IsSubclassOf(typeof(ODataController));
        }

        public bool AppliesToAction(ODataControllerActionContext context)
        {
            var actionName = context.Action.ActionName;

            // If the action name matches, add a custom route
            if (actionName == "GetSingle" || actionName == "GetList")
            {
                // Ensure there is at least one parameter before accessing it
                if (context.Action.Parameters.Count > 0 &&
                    context.Action.Parameters[0].ParameterType == typeof(Guid))
                {
                    // Map to the OData key route
                    context.Action.AddSelector(context.Prefix, $"odata/{context.Controller.ControllerName}({{key}})", context.Model, null, null);
                }
                else
                {
                    // Map to the entity set route
                    context.Action.AddSelector(context.Prefix, $"odata/{context.Controller.ControllerName}", context.Model, null, null);
                }
                return true;
            }

            return false;
        }
    }
}
