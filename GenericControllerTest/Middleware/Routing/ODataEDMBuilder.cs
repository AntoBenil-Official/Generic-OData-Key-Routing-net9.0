using GenericControllerTest.Common;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace GenericControllerTest.Middleware.Routing
{
    public class ODataEDMBuilder
    {
        private static IEdmModel _model;

        public static IEdmModel GetEdmModel()
        {
            if (_model != null)
            {
                return _model;
            }
            var builder = new ODataConventionModelBuilder
            {
                Namespace = "WebAPI",
                ContainerName = "DefaultContainer"
            };

            foreach (Type item in MfgCommon.GetTypesInNamespace())
            {
                EntityTypeConfiguration entityType = builder.AddEntityType(item);
                builder.AddEntityType(item).HasKey(item.GetProperty("Id"));
                builder.AddEntitySet(item.Name, entityType);
            }
            _model = builder.GetEdmModel();

            return _model;
        }
    }
}
