namespace Wingine
{
    public static class ResourceManager
    {
        public static object Get(string name)
        {
            if (Runner.CurrentProject?.Item4?.ContainsKey(name) ?? false)
            {
                return Runner.CurrentProject.Item4[name];
            }

            return null;
        }

        public static void Set(string name, object value)
        {
            Runner.CurrentProject.Item4[name] = value;
        }
    }
}
