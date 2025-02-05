using System.Reflection;

namespace GenericControllerTest.Common
{
    public class MfgCommon
    {

        private const string nameSpace = "West.Manufacturing.Model";
        protected MfgCommon() { }

        public static Type[] GetTypesInNamespace()
        {
            Assembly assembly = Assembly.Load(nameSpace);
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }
    }
}
