using System.Collections.Generic;

namespace Wingine
{
    /// TODO: Fix Semi-Crash Issue
    public static class ResourceManager
    {
        public static event ResourcesCD ResourcesChanged;
        public delegate void ResourcesCD();

        public static object Get(string name)
        {
            if (Runner.CurrentProject?.Item5?.ContainsKey(name.Trim()) ?? false)
            {
                return Runner.CurrentProject.Item5[name.Trim()];
            }

            return null;
        }

        
        public static void Set(string name, object value, bool updateEvent = true)
        {
            Runner.CurrentProject.Item5[name.Trim()] = value;

            Runner.CurrentProject.Item5.Remove("");

            if (updateEvent) ResourcesChanged?.Invoke();
        }

        public static void Remove(string name, bool updateEvent = true)
        {
            Runner.CurrentProject.Item5.Remove(name);

            if (updateEvent) ResourcesChanged?.Invoke();
        }

        public static void RemoveAll(bool updateEvent = true)
        {
            Runner.CurrentProject.Item4.Clear();

            if (updateEvent) ResourcesChanged?.Invoke();
        }

        public static Dictionary<string, object> GetAll() => Runner.CurrentProject.Item5;
    }
}
