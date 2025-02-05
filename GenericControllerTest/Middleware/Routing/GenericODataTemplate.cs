using Microsoft.AspNetCore.OData.Routing.Template;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.OData.UriParser;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericControllerTest.Middleware.Routing
{
    public class GenericODataTemplate : ODataSegmentTemplate
    {
        public string TemplateName { get; }
        public GenericODataTemplate(string typeName)
        {
            TemplateName = typeName;
        }

        public override IEnumerable<string> GetTemplates(ODataRouteOptions options)
        {
            yield return $"/{TemplateName}";
            yield return $"/{TemplateName}({{key}})";
        }

        public override bool TryTranslate(ODataTemplateTranslateContext context)
        {
            // Find the entity set by matching the type name
            var entitySet = context.Model.EntityContainer.EntitySets()
                .FirstOrDefault(e => string.Equals(e.EntityType().Name, TemplateName, StringComparison.OrdinalIgnoreCase));

            if (entitySet != null)
            {
                if (context.RouteValues.TryGetValue("key", out var keyValue))
                {
                    KeySegment keySegment = new KeySegment(
                        new[] { new KeyValuePair<string, object>("Id", keyValue) },
                        entitySet.EntityType(),
                        entitySet);

                    context.Segments.Add(keySegment);
                }
                else
                {
                    EntitySetSegment segment = new EntitySetSegment(entitySet);
                    context.Segments.Add(segment);
                }

                return true;
            }

            return false;
        }
    }
}